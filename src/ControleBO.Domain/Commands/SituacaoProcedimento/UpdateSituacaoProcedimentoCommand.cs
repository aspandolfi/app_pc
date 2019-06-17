using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdateSituacaoProcedimentoCommand : SituacaoProcedimentoCommand
    {
        public UpdateSituacaoProcedimentoCommand(int id, int procedimentoId, int situacaoId, int? situacaoTipoId, DateTime? dataRelatorio, string observacao = null)
        {
            Id = id;
            ProcedimentoId = procedimentoId;
            SituacaoId = situacaoId;
            SituacaoTipoId = situacaoTipoId;
            DataRelatorio = dataRelatorio;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSituacaoProcedimentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
