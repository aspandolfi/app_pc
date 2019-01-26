using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Indiciado : Entity
    {
        public Indiciado(string apelido, Procedimento procedimento, Pessoa pessoa)
        {
            Apelido = apelido;
            Pessoa = pessoa;
            Procedimento = procedimento;
        }

        protected Indiciado() { }

        public string Apelido { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
