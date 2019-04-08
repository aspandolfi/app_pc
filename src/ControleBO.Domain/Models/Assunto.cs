using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Assunto : Entity
    {
        public Assunto(string descricao)
        {
            Descricao = descricao;
        }

        public Assunto(int id, string descricao)
            : this(descricao)
        {
            Id = id;
        }

        protected Assunto() { }

        public string Descricao { get; set; }
    }
}
