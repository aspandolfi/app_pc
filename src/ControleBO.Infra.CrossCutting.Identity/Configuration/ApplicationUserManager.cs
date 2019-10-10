using ControleBO.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControleBO.Infra.CrossCutting.Identity.Configuration
{
    public class ApplicationUserManager : AspNetUserManager<ApplicationUser>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfigurations _signingConfigurations;

        public ApplicationUserManager(IUserStore<ApplicationUser> store,
                                      IOptions<IdentityOptions> optionsAccessor,
                                      IPasswordHasher<ApplicationUser> passwordHasher,
                                      IEnumerable<IUserValidator<ApplicationUser>> userValidators,
                                      IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
                                      ILookupNormalizer keyNormalizer,
                                      IdentityErrorDescriber errors,
                                      IServiceProvider services,
                                      ILogger<UserManager<ApplicationUser>> logger,
                                      SignInManager<ApplicationUser> signInManager,
                                      TokenConfigurations tokenConfigurations,
                                      SigningConfigurations signingConfigurations)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
        }

        public async Task<LoginResult> Login(ApplicationUser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                return new LoginResult(result);
            }

            var token = await GenerateToken(user);

            return new LoginResult(result, token);
        }

        private async Task<AuthenticationResult> GenerateToken(ApplicationUser user)
        {
            var roles = await GetRolesAsync(user);
            var claims = await GetClaimsAsync(user);

            ClaimsIdentity identity = user.GenerateClaimsIdentity(ClaimsIdentity.DefaultRoleClaimType, roles);

            identity.AddClaims(claims);

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            await SetAuthenticationTokenAsync(user, JwtConstants.TokenType, TokenConfigurations.RefreshToken, token);

            return new AuthenticationResult(true, dataCriacao, dataExpiracao, token);
        }

        public async Task<LoginResult> RefreshToken(ApplicationUser user, string token)
        {
            if (!await IsValidToken(user, token))
            {
                return new LoginResult(new List<IdentityError> { new IdentityError { Code = "Not found", Description = "Autenticação inválida." } }, succeeded: false);
            }

            var result = await RemoveToken(user);

            if (!result.Succeeded)
            {
                return new LoginResult(result);
            }

            var newToken = await GenerateToken(user);

            return new LoginResult(null, newToken, true);
        }

        public Task<IdentityResult> RemoveToken(ApplicationUser user)
        {
            return RemoveAuthenticationTokenAsync(user, JwtConstants.TokenType, TokenConfigurations.RefreshToken);
        }

        public async Task<bool> IsValidToken(ApplicationUser user, string token)
        {
            var dbToken = await GetAuthenticationTokenAsync(user, JwtConstants.TokenType, TokenConfigurations.RefreshToken);

            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(dbToken))
            {
                return false;
            }

            if (token.CompareTo(dbToken) != 0)
            {
                return false;
            }

            var securityToken = handler.ReadToken(dbToken);

            return securityToken.ValidTo >= DateTime.Now;
        }
    }

    public class LoginResult : IdentityResult
    {
        private IEnumerable<IdentityError> _errors;

        public new IEnumerable<IdentityError> Errors
        {
            get
            {
                return _errors;
            }
            private set
            {
                if (value != null)
                {
                    _errors = new List<IdentityError>(value);
                }
            }
        }

        public AuthenticationResult Authentication { get; }

        public LoginResult(IdentityResult identityResult)
        {
            Errors = identityResult.Errors;
            Succeeded = identityResult.Succeeded;
        }

        public LoginResult(SignInResult signInResult)
        {
            Succeeded = signInResult.Succeeded;
        }

        public LoginResult(SignInResult signInResult, AuthenticationResult authenticationResult)
            : this(signInResult)
        {
            Authentication = authenticationResult;
            Succeeded = signInResult.Succeeded;
        }

        public LoginResult(IEnumerable<IdentityError> identityErrors, AuthenticationResult authentication = null, bool succeeded = true)
        {
            Errors = identityErrors;
            Authentication = authentication;
            Succeeded = succeeded;
        }
    }
}
