using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ControleBO.Infra.CrossCutting.Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome deve conter no mínimo 5 e no máximo 100 caracteres.", MinimumLength = 5)]
        [Display(Name = "Nome")]
        [JsonProperty(PropertyName = "nome")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter no mínimo {2} e no máximo {1} dígitos.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [JsonProperty(PropertyName = "senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha devem ser iguais.")]
        [JsonProperty(PropertyName = "confirmarSenha")]
        public string ConfirmPassword { get; set; }

        public void Clean()
        {
            Password = null;
            ConfirmPassword = null;
        }
    }
}
