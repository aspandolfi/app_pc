using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public class SituacaoProcedimento : Entity
    {
        public SituacaoProcedimento(Procedimento procedimento, Situacao situacao, SituacaoTipo situacaoTipo = null, DateTime? dataRelatorio = null, string observacao = null)
        {
            Procedimento = procedimento;
            Situacao = situacao;
            SituacaoTipo = situacaoTipo;
            DataRelatorio = dataRelatorio;
            Observacao = observacao;
        }

        public SituacaoProcedimento(int id, Procedimento procedimento, Situacao situacao, SituacaoTipo situacaoTipo = null, DateTime? dataRelatorio = null, string observacao = null)
            : this(procedimento, situacao, situacaoTipo, dataRelatorio, observacao)
        {
            Id = id;
        }

        protected SituacaoProcedimento() { }

        public DateTime? DataRelatorio { get; set; }

        public string Observacao { get; set; }

        public virtual Procedimento Procedimento { get; set; }

        public virtual Situacao Situacao { get; set; }

        public virtual SituacaoTipo SituacaoTipo { get; set; }
    }
}
