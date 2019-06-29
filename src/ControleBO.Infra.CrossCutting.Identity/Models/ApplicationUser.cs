using Microsoft.AspNetCore.Identity;

namespace ControleBO.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
