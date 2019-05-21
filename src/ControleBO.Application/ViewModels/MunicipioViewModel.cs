using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class MunicipioViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }

        [JsonProperty(PropertyName = "cep")]
        public string CEP { get; set; }
    }
}
