using Newtonsoft.Json;
using System;

namespace ControleBO.Application.ViewModels
{
    public class SituacaoProcedimentoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "dataRelatorio")]
        public DateTime? DataRelatorio { get; set; }

        [JsonProperty(PropertyName = "observacao")]
        public string Observacao { get; set; }

        [JsonProperty(PropertyName = "procedimentoId")]
        public int ProcedimentoId { get; set; }

        [JsonProperty(PropertyName = "situacaoId")]
        public int SituacaoId { get; set; }

        [JsonProperty(PropertyName = "situacaoTipoId")]
        public int? SituacaoTipoId { get; set; }
    }
}
