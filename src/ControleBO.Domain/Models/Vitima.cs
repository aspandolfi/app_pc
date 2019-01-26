using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Vitima : Entity
    {
        public Vitima(string email, Procedimento procedimento, Pessoa pessoa)
        {
            Email = email;
            Procedimento = procedimento;
        }

        protected Vitima() { }

        public string Email { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
