using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class UnidadePolicialViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "codigo")]
        public string Codigo { get; set; }

        [JsonProperty(PropertyName = "sigla")]
        public string Sigla { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "codigoCargoQO")]
        public string CodigoCargoQO { get; set; }
    }
}
