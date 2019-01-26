using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Artigo : Entity
    {
        public Artigo(string descricao)
        {
            Descricao = descricao;
        }

        protected Artigo() { }

        public string Descricao { get; set; }
    }
}
