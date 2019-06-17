using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateSituacaoProcedimentoCommandValidation : SituacaoProcedimentoValidation<UpdateSituacaoProcedimentoCommand>
    {
        public UpdateSituacaoProcedimentoCommandValidation()
        {
            ValidateId();
            ValidateDataRelatorio();
            ValidateObservacao();
            ValidateProcedimentoId();
            ValidateSituacaoId();
            ValidateSituacaoTipoId();
        }
    }
}
