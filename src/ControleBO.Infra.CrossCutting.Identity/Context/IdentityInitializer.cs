using ControleBO.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace ControleBO.Infra.CrossCutting.Identity.Context
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.Admin)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.Admin}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "aspandolfi",
                        Email = "aspandolfi@gmail.com",
                        EmailConfirmed = true
                    }, "Aspandolf1!");
            }
        }

        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }

    }
}
