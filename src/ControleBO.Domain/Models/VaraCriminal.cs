using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class VaraCriminal : Entity
    {
        public VaraCriminal(string descricao)
        {
            Descricao = descricao;
        }

        public VaraCriminal(int id, string descricao) : this(descricao)
        {
            Id = id;
        }

        protected VaraCriminal() { }

        public string Descricao { get; set; }
    }
}
