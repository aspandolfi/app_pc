using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class SituacaoProcedimento : Entity
    {
        public SituacaoProcedimento(Procedimento procedimento, Situacao situacao, SituacaoTipo situacaoTipo = null)
        {
            Procedimento = procedimento;
            Situacao = situacao;
            SituacaoTipo = situacaoTipo;
        }

        protected SituacaoProcedimento() { }

        public virtual Procedimento Procedimento { get; set; }

        public virtual Situacao Situacao { get; set; }

        public virtual SituacaoTipo SituacaoTipo { get; set; }
    }
}
