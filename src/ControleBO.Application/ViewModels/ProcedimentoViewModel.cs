﻿using ControleBO.Application.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ControleBO.Application.ViewModels
{
    public class ProcedimentoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "boletimUnificado")]
        public string BoletimUnificado { get; set; }

        [JsonProperty(PropertyName = "boletimOcorrencia")]
        public string BoletimOcorrencia { get; set; }

        [JsonProperty(PropertyName = "numeroProcessual")]
        public string NumeroProcessual { get; set; }

        [JsonProperty(PropertyName = "gampes")]
        public string Gampes { get; set; }

        [JsonProperty(PropertyName = "anexos")]
        public string Anexos { get; set; }

        [JsonProperty(PropertyName = "localFato")]
        public string LocalFato { get; set; }

        [JsonProperty(PropertyName = "dataInsercao")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "dataFato")]
        [JsonConverter(typeof(DateTimeOffSetConverter))]
        public DateTime? DataFato { get; set; }

        [JsonProperty(PropertyName = "dataInstauracao")]
        [JsonConverter(typeof(DateTimeOffSetConverter))]
        public DateTime? DataInstauracao { get; set; }

        [JsonProperty(PropertyName = "tipoCriminal")]
        public string TipoCriminal { get; set; }

        [JsonProperty(PropertyName = "andamentoProcessual")]
        public string AndamentoProcessual { get; set; }

        [JsonProperty(PropertyName = "tipoProcedimentoId")]
        public int? TipoProcedimentoId { get; set; }

        [JsonProperty(PropertyName = "varaCriminalId")]
        public int? VaraCriminalId { get; set; }

        [JsonProperty(PropertyName = "comarcaId")]
        public int? ComarcaId { get; set; }

        [JsonProperty(PropertyName = "assuntoId")]
        public int? AssuntoId { get; set; }

        [JsonProperty(PropertyName = "artigoId")]
        public int? ArtigoId { get; set; }

        [JsonProperty(PropertyName = "delegaciaId")]
        public int? DelegaciaOrigemId { get; set; }

        [JsonProperty(PropertyName = "vitimas")]
        public IEnumerable<VitimaViewModel> Vitimas { get; set; }

        [JsonProperty(PropertyName = "indiciados")]
        public IEnumerable<IndiciadoViewModel> Autores { get; set; }

        [JsonProperty(PropertyName = "objetosApreendidos")]
        public IEnumerable<ObjetoApreendidoViewModel> ObjetosApreendidos { get; set; }

        [JsonProperty(PropertyName = "movimentacoes")]
        public IEnumerable<MovimentacaoViewModel> Movimentacoes { get; set; }
    }
}
