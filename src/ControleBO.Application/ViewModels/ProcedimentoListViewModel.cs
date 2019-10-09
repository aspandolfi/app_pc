using Newtonsoft.Json;
using System;

namespace ControleBO.Application.ViewModels
{
    public class ProcedimentoListViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "boletimUnificado")]
        public string BoletimUnificado { get; set; }

        [JsonProperty(PropertyName = "boletimOcorrencia")]
        public string BoletimOcorrencia { get; set; }

        [JsonProperty(PropertyName = "numeroProcessual")]
        public string NumeroProcessual { get; set; }

        [JsonProperty(PropertyName = "tipoProcedimento")]
        public string TipoProcedimento { get; set; }

        [JsonProperty(PropertyName = "dataInsercao")]
        public DateTime DataInsercao { get; set; }

        [JsonProperty(PropertyName = "comarca")]
        public string Comarca { get; set; }

        [JsonProperty(PropertyName = "andamentoProcessual")]
        public string AndamentoProcessual { get; set; }

        [JsonProperty(PropertyName = "vitimas")]
        public string Vitimas { get; set; }
    }
}
