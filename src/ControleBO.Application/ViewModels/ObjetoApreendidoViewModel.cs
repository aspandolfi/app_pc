using ControleBO.Application.Converters;
using Newtonsoft.Json;
using System;

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

        [JsonProperty(PropertyName = "dataApreensao")]
        [JsonConverter(typeof(DateTimeOffSetConverter))]
        public DateTime? DataApreensao { get; set; }

        [JsonProperty(PropertyName = "dataInsercao")]
        public DateTime? CriadoEm { get; set; }
    }
}
