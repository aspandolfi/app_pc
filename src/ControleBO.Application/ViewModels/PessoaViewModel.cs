﻿using ControleBO.Application.Converters;
using Newtonsoft.Json;
using System;

namespace ControleBO.Application.ViewModels
{
    public class PessoaViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "nomePai")]
        public string NomePai { get; set; }

        [JsonProperty(PropertyName = "nomeMae")]
        public string NomeMae { get; set; }

        [JsonProperty(PropertyName = "dataNascimento")]
        [JsonConverter(typeof(DateTimeOffSetConverter))]
        public DateTime? DataNascimento { get; set; }

        [JsonProperty(PropertyName = "idade")]
        public int? Idade { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "naturalidadeId")]
        public int? NaturalidadeId { get; set; }

        [JsonProperty(PropertyName = "naturalidade")]
        public string Naturalidade { get; set; }
    }
}
