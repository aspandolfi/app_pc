using System;

namespace ControleBO.Domain.Models
{
    public class Indiciado : Pessoa
    {
        public Indiciado(string apelido, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio municipio)
            : base(nome, nomePai, nomeMae, dataNascimento, idade, telefone, municipio)
        {
            Apelido = apelido;
            Procedimento = procedimento;
        }

        public Indiciado(int id, string apelido, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio municipio)
            : this(apelido, procedimento, nome, nomePai, nomeMae, dataNascimento, idade, telefone, municipio)
        {
            Id = id;
        }

        protected Indiciado() { }

        public string Apelido { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
