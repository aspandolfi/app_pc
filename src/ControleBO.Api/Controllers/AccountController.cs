using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ControleBO.Api.Configurations;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Infra.CrossCutting.Identity.Configuration;
using ControleBO.Infra.CrossCutting.Identity.Models;
using ControleBO.Infra.CrossCutting.Identity.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 SigningConfigurations signingConfigurations,
                                 TokenConfigurations tokenConfigurations,
                                 INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _userManager.Users.ToList();

            var usuariosVm = usuarios.Select(u => new ApplicationUserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                Nome = u.Name
            });

            return Response(usuariosVm);
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(user);
            }

            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, true);
            if (!result.Succeeded)
            {
                NotifyError(result.ToString(), "Falha ao logar");
                return Response(user, "Usuário ou senha inválido.");
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    });

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

            return Response(new AuthenticationResultViewModel(true,
                                                              dataCriacao,
                                                              dataExpiracao,
                                                              token));
        }

        [HttpPost]
        [Authorize(Policy = "Bearer")]
        public async Task<IActionResult> Create([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model, "Por favor verifique os campos preenchidos.");
            }

            var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                //await _userManager.AddClaimAsync(user, new Claim("Users", "Admin"));
                await _userManager.AddToRoleAsync(user, "Admin");

                //await _signInManager.SignInAsync(user, false);
                return Response(model, "O usuário foi cadastro com sucesso!");
            }

            AddIdentityErrors(result);
            return Response(model, "Falha ao cadastrar o usuário.");
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
