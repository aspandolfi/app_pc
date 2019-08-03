using ControleBO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace ControleBO.Infra.CrossCutting.Identity.Models
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _httpContext;

        public AspNetUser(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string Name => _httpContext.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> Claims => _httpContext.HttpContext.User.Claims;

        public bool IsInRole(string role)
        {
            return _httpContext.HttpContext.User.IsInRole(role);
        }
    }
}
