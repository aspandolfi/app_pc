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

        public int ProcedimentoId { get; set; }

        public virtual Procedimento Procedimento { get; set; }

        public int SituacaoId { get; set; }

        public virtual Situacao Situacao { get; set; }

        public int? SituacaoTipoId { get; set; }

        public virtual SituacaoTipo SituacaoTipo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is SituacaoProcedimento))
            {
                return false;
            }

            var situacaoProcedimento = obj as SituacaoProcedimento;

            if (situacaoProcedimento.SituacaoTipoId.HasValue && SituacaoTipoId.HasValue)
            {
                return this.Id == situacaoProcedimento.Id
                    && this.Procedimento.Id == situacaoProcedimento.ProcedimentoId
                    && this.Situacao.Id == situacaoProcedimento.SituacaoId
                    && this.SituacaoTipo.Id == situacaoProcedimento.SituacaoTipoId;
            }

            return this.Id == situacaoProcedimento.Id
                    && this.Procedimento.Id == situacaoProcedimento.ProcedimentoId
                    && this.Situacao.Id == situacaoProcedimento.SituacaoId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
