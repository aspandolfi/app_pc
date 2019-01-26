using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class VaraCriminal : Entity
    {
        public VaraCriminal(string descricao)
        {
            Descricao = descricao;
        }

        protected VaraCriminal() { }

        public string Descricao { get; set; }
    }
}
