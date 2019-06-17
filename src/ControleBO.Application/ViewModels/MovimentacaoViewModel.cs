using Newtonsoft.Json;
using System;

namespace ControleBO.Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "destino")]
        public string Destino { get; set; }

        [JsonProperty(PropertyName = "data")]
        public DateTime Data { get; set; }

        [JsonProperty(PropertyName = "retornouEm")]
        public DateTime? RetornouEm { get; set; }

        [JsonProperty(PropertyName = "procedimentoId")]
        public int ProcedimentoId { get; set; }
    }
}
