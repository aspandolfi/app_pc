using System;

namespace ControleBO.Domain.Models
{
    public class Vitima : Pessoa
    {
        public Vitima(string email, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio naturalidade)
            : base(nome, nomePai, nomeMae, dataNascimento, idade, telefone, naturalidade)
        {
            Email = email;
            Procedimento = procedimento;
        }

        public Vitima(int id, string email, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio naturalidade)
            : this(email, procedimento, nome, nomePai, nomeMae, dataNascimento, idade, telefone, naturalidade)
        {
            Id = id;
        }

        protected Vitima() { }

        public string Email { get; set; }

        public int ProcedimentoId { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
