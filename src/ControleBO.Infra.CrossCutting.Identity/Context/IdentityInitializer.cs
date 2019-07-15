using ControleBO.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        private bool IsIdentityCreated()
        {
            var sqlRaw = @"SELECT EXISTS (
                                       SELECT 1
                                       FROM information_schema.tables
                                     WHERE table_name = 'AspNetUsers'
                                       ); ";
            var query = _context.Database.ExecuteSqlCommand(new RawSqlString(sqlRaw));

            return query > 0;
        }

        private void CreateIdentityIfNotExists()
        {
            if (!IsIdentityCreated())
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
        }

        private void CreateRolesIfNotExists()
        {
            foreach (var role in Roles.GetAll)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(role)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {role}.");
                    }
                }
            }
        }

        private void CreateSuperUserIfNotExists()
        {
            CreateUser(
                    new ApplicationUser()
                    {
                        Name = "André Serafim Pandolfi",
                        UserName = "aspandolfi",
                        Email = "aspandolfi@gmail.com",
                        EmailConfirmed = true
                    }, "and1991",
                    Roles.SuperUser);
        }

        public void Initialize()
        {
            CreateIdentityIfNotExists();
            CreateRolesIfNotExists();
            CreateSuperUserIfNotExists();
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
