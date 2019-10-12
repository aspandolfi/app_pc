using System;

namespace ControleBO.Domain.Models
{
    public class Indiciado : Pessoa
    {
        public Indiciado(string apelido, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, string telefone, Municipio municipio)
            : base(nome, nomePai, nomeMae, dataNascimento, telefone, municipio)
        {
            Apelido = apelido;
            Procedimento = procedimento;
        }

        public Indiciado(int id, string apelido, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, string telefone, Municipio municipio)
            : this(apelido, procedimento, nome, nomePai, nomeMae, dataNascimento, telefone, municipio)
        {
            Id = id;
        }

        protected Indiciado() { }

        public string Apelido { get; set; }

        public int ProcedimentoId { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
