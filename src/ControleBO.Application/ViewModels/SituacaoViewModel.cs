using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class SituacaoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "tipos")]
        public SituacaoTipoViewModel[] Tipos { get; set; }
    }
}
