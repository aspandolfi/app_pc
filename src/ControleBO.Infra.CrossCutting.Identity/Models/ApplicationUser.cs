using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace ControleBO.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }

    public static class ApplicationUserExtensions
    {
        public static ClaimsIdentity GenerateClaimsIdentity(this ApplicationUser user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(user.Email, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        //new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                   });

            return identity;
        }

        public static ClaimsIdentity GenerateClaimsIdentity(this ApplicationUser user, string claimType, string claim)
        {
            ClaimsIdentity identity = GenerateClaimsIdentity(user);

            identity.AddClaim(new Claim(claimType, claim));

            return identity;
        }

        public static ClaimsIdentity GenerateClaimsIdentity(this ApplicationUser user, string claimType, IEnumerable<string> claims)
        {
            ClaimsIdentity identity = GenerateClaimsIdentity(user);

            foreach (var claim in claims)
            {
                identity.AddClaim(new Claim(claimType, claim));
            }

            return identity;
        }
    }
}
