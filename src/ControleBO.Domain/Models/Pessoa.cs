using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public class Pessoa : Entity
    {
        public Pessoa(string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, bool menorIdade, string telefone, Municipio naturalidade)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Idade = idade;
            MenorIdade = menorIdade;
            Telefone = telefone;
            Naturalidade = naturalidade;
        }

        protected Pessoa() { }

        public string Nome { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int? Idade { get; set; }

        public bool MenorIdade { get; set; }

        public string Telefone { get; set; }

        public virtual Municipio Naturalidade { get; set; }
    }
}
