using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class ObjetoApreendidoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "local")]
        public string Local { get; set; }

        [JsonProperty(PropertyName = "procedimentoId")]
        public int ProcedimentoId { get; set; }
    }
}
