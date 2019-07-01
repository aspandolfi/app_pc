using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ControleBO.Infra.CrossCutting.Identity.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O campo e-mail não é válido.")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "rememberMe")]
        public bool RememberMe { get; set; }
    }
}
