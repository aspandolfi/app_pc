using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Artigo : Entity
    {
        public Artigo(string descricao)
        {
            Descricao = descricao;
        }

        public Artigo(int id, string descricao)
            : this(descricao)
        {
            Id = id;
        }

        protected Artigo() { }

        public string Descricao { get; set; }
    }
}
