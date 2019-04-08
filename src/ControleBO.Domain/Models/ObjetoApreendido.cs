using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class ObjetoApreendido : Entity
    {
        public ObjetoApreendido(string descricao, string local, Procedimento procedimento)
        {
            Descricao = descricao;
            Local = local;
            Procedimento = procedimento;
        }

        public ObjetoApreendido(int id, string descricao, string local, Procedimento procedimento)
            : this(descricao, local, procedimento)
        {
            Id = id;
        }

        protected ObjetoApreendido() { }

        public string Descricao { get; set; }

        public string Local { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
