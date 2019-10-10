using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Infra.CrossCutting.Identity.Configuration;
using ControleBO.Infra.CrossCutting.Identity.Models;
using ControleBO.Infra.CrossCutting.Identity.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IAspNetUser _aspNetUser;

        public AccountController(SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IAspNetUser aspNetUser,
                                 SigningConfigurations signingConfigurations,
                                 TokenConfigurations tokenConfigurations,
                                 ApplicationUserManager applicationUserManager,
                                 INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _aspNetUser = aspNetUser;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _applicationUserManager = applicationUserManager;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult Get()
        {
            List<ApplicationUser> usuarios;
            List<ApplicationUserViewModel> usuariosVm;

            var currentUser = _aspNetUser;

            if (currentUser.IsInRole(Roles.SuperUser) || currentUser.IsInRole(Roles.Admin))
            {
                usuarios = _applicationUserManager.Users
                .Where(x => x.Email != Roles.SuperUserEmail).ToList();

                usuariosVm = usuarios.Select(user => new ApplicationUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Nome = user.Name,
                    Regra = _applicationUserManager.GetRolesAsync(user).Result.FirstOrDefault()
                }).ToList();

                return Response(usuariosVm);
            }

            usuarios = _applicationUserManager.Users
               .Where(x => x.Email != Roles.SuperUserEmail && x.Id == currentUser.Id).ToList();

            usuariosVm = usuarios.Select(user => new ApplicationUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Nome = user.Name,
                Regra = _applicationUserManager.GetRolesAsync(user).Result.FirstOrDefault()
            }).ToList();

            return Response(usuariosVm);
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Response(null, "Id inválido.");
            }

            var user = await _applicationUserManager.FindByIdAsync(id);

            if (user == null)
            {
                return Response(null, "Usuário não encontrado.");
            }

            var roles = await _applicationUserManager.GetRolesAsync(user);

            return Response(new ApplicationUserViewModel
            {
                Nome = user.Name,
                Regra = roles.FirstOrDefault()
            });
        }

        // GET: api/Account/Current
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            var userId = _aspNetUser.Id;

            var user = await _applicationUserManager.FindByIdAsync(userId);

            if (user == null)
            {
                NotifyError("Current", "Usuário não encontrado.");
                return Response();
            }

            var roles = await _applicationUserManager.GetRolesAsync(user);

            return Response(new ApplicationUserViewModel
            {
                Nome = user.Name,
                Regra = roles.FirstOrDefault()
            });
        }

        // GET: api/Account/getbyemail/email@email.com
        [HttpGet("getbyemail/{email}")]
        public async Task<IActionResult> GetByEmail([EmailAddress]string email)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(null, "E-mail inválido.");
            }

            var user = await _applicationUserManager.FindByEmailAsync(email);

            if (user == null)
            {
                NotifyError("GetByEmail", "E-mail não encontrado.");
                return Response();
            }

            var roles = await _applicationUserManager.GetRolesAsync(user);

            return Response(new ApplicationUserViewModel
            {
                Nome = user.Name,
                Regra = roles.FirstOrDefault()
            });
        }

        // POST: api/Account/Refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var userId = _aspNetUser.Id;

            var user = await _applicationUserManager.FindByIdAsync(userId);

            if (user == null)
            {
                NotifyError("refresh", "Usuário não encontrado.");
                return Response();
            }

            var result = await _applicationUserManager.RefreshToken(user, await GetBearerToken());

            if (!result.Succeeded)
            {
                AddIdentityErrors(result);
                return Response();
            }

            return Response(result.Authentication);
        }

        // POST: api/Account/Logout
        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            var userId = _aspNetUser.Id;

            var user = await _applicationUserManager.FindByIdAsync(userId);

            if (user == null)
            {
                NotifyError("refresh", "Usuário não encontrado.");
                return Response();
            }

            var result = await _applicationUserManager.RemoveToken(user);

            if (!result.Succeeded)
            {
                AddIdentityErrors(result);
                return Response();
            }

            return Response();
        }

        // POST: api/Account
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userVm);
            }

            var user = await _applicationUserManager.FindByEmailAsync(userVm.Email);

            if (user == null)
            {
                NotifyError("Usuário inválido", "Falha ao logar");
                return Response(userVm, "Usuário inválido.");
            }

            var result = await _applicationUserManager.Login(user, userVm.Password);

            if (!result.Succeeded)
            {
                NotifyError(result.ToString(), "Falha ao logar");
                return Response(userVm, "Usuário ou senha inválido.");
            }

            return Response(result.Authentication);
        }

        [HttpPost]
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public async Task<IActionResult> Create([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model, "Por favor verifique os campos preenchidos.");
            }

            var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email };

            var result = await _applicationUserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                //await _applicationUserManager.AddClaimAsync(user, new Claim("Users", "Admin"));

                if (!string.IsNullOrEmpty(model.Role))
                {
                    if (Roles.Contains(model.Role))
                    {
                        await _applicationUserManager.AddToRoleAsync(user, model.Role);
                    }
                }

                //await _signInManager.SignInAsync(user, false);
                model.Clean();
                return Response(model, "O usuário foi cadastro com sucesso!");
            }

            AddIdentityErrors(result);

            model.Clean();

            return Response(model, "Falha ao cadastrar o usuário.");
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model, "Por favor verifique os campos preenchidos.");
            }

            bool atualizarSenha = false;

            if (!string.IsNullOrEmpty(model.Password))
            {
                if (string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    NotifyError("UpdateUser", "Por favor preencha a senha e a confirmação de senha.");
                    return Response(model);
                }

                if (string.Compare(model.Password, model.ConfirmPassword) != 0)
                {
                    NotifyError("UpdateUser", "A senha e a confirmação de senha não conferem.");
                    return Response(model);
                }

                if (string.IsNullOrEmpty(model.CurrentPassword))
                {
                    NotifyError("UpdateUser", "Por favor preencha a senha atual.");
                    return Response(model);
                }

                atualizarSenha = true;
            }

            var user = await _applicationUserManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                NotifyError("UpdateUser", "O usuário não foi encontrado.");
                return Response(model);
            }

            user.Name = model.Name.Trim();
            user.Email = model.Email.Trim();

            var result = await _applicationUserManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                AddIdentityErrors(result);
                return Response(model, "Falha ao atualizar o usuário.");
            }

            if (atualizarSenha)
            {
                result = await _applicationUserManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

                if (!result.Succeeded)
                {
                    AddIdentityErrors(result);
                    return Response(model, "Falha ao atualizar o usuário.");
                }
            }

            var roles = await _applicationUserManager.GetRolesAsync(user);

            if (!roles.Contains(model.Role))
            {
                await _applicationUserManager.RemoveFromRolesAsync(user, roles);

                if (Roles.Contains(model.Role))
                {
                    await _applicationUserManager.AddToRoleAsync(user, model.Role);
                }
            }

            model.Clean();

            return Response(model, "O usuário foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                NotifyError("DeleteUser", "Por favor, verifique se o usuário existe.");
                return Response(id);
            }

            var user = await _applicationUserManager.FindByIdAsync(id);

            if (user == null)
            {
                NotifyError("DeleteUser", "Por favor, verifique se o usuário existe.");
                return Response(id);
            }

            var result = await _applicationUserManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                NotifyError("DeleteUser", "Desculpe, falha ao remover o usuário.");
                return Response(id);
            }

            return Response(id, "O usuário foi removido com sucesso.");
        }
    }
}
