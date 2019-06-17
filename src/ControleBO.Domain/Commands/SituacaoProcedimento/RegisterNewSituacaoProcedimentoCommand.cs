using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewSituacaoProcedimentoCommand : SituacaoProcedimentoCommand
    {
        public RegisterNewSituacaoProcedimentoCommand(int procedimentoId, int situacaoId, int? situacaoTipoId, DateTime? dataRelatorio, string observacao = null)
        {
            ProcedimentoId = procedimentoId;
            SituacaoId = situacaoId;
            SituacaoTipoId = situacaoTipoId;
            DataRelatorio = dataRelatorio;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewSituacaoProcedimentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
