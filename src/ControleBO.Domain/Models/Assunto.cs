using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Assunto : Entity
    {
        public Assunto(string descricao)
        {
            Descricao = descricao;
        }

        protected Assunto() { }

        public string Descricao { get; set; }
    }
}
