using System.Collections.Generic;
using System.Security.Claims;

namespace ControleBO.Domain.Interfaces
{
    public interface IAspNetUser
    {
        string Name { get; }

        IEnumerable<Claim> Claims { get; }

        bool IsInRole(string role);
    }
}
