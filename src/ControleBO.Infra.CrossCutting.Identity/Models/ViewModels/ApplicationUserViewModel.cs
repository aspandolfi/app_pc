using Newtonsoft.Json;

namespace ControleBO.Infra.CrossCutting.Identity.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "regra")]
        public string Regra { get; set; }
    }
}
