using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleBO.Application.ViewModels
{
    public class SituacaoTipoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "situacaoId")]
        public int SituacaoId { get; set; }
    }
}
