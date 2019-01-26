using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class SituacaoTipo : Entity
    {
        public SituacaoTipo(string descricao, Situacao situacao)
        {
            Descricao = descricao;
            Situacao = situacao;
        }

        protected SituacaoTipo() { }

        public string Descricao { get; set; }

        public virtual Situacao Situacao { get; set; }
    }
}
