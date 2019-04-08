using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public abstract class Pessoa : Entity
    {
        public Pessoa(string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio naturalidade)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Idade = idade;
            Telefone = telefone;
            Naturalidade = naturalidade;
        }

        public Pessoa(int id, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio naturalidade)
            : this(nome, nomePai, nomeMae, dataNascimento, idade, telefone, naturalidade)
        {
            Id = id;
        }

        protected Pessoa() { }

        public string Nome { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int? Idade { get; set; }

        public bool MenorIdade
        {
            get
            {
                if (DataNascimento.HasValue)
                {
                    return (DateTime.Now - DataNascimento).Value.TotalDays < (18 * 365);
                }

                if (Idade.HasValue)
                {
                    return Idade < 18;
                }

                return false;
            }
            set
            {
                if (DataNascimento.HasValue)
                {
                    MenorIdade = (DateTime.Now - DataNascimento).Value.TotalDays < (18 * 365);
                }

                if (Idade.HasValue)
                {
                    MenorIdade = Idade < 18;
                }
            }
        }

        public string Telefone { get; set; }

        public virtual Municipio Naturalidade { get; set; }
    }
}
