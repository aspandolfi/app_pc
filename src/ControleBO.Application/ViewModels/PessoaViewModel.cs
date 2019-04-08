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
        public DateTime? DataNascimento { get; set; }

        [JsonProperty(PropertyName = "idade")]
        public int? Idade { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "municipio")]
        public int MunicipioId { get; set; }
    }
}
