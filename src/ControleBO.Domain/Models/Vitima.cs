using System;

namespace ControleBO.Domain.Models
{
    public class Vitima : Pessoa
    {
        public Vitima(string email, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio municipio)
            : base(nome, nomePai, nomeMae, dataNascimento, idade, telefone, municipio)
        {
            Email = email;
            Procedimento = procedimento;
        }

        public Vitima(int id, string email, Procedimento procedimento, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, Municipio municipio)
            : this(email, procedimento, nome, nomePai, nomeMae, dataNascimento, idade, telefone, municipio)
        {
            Id = id;
        }

        protected Vitima() { }

        public string Email { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
