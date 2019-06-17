using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewSituacaoProcedimentoCommandValidation : SituacaoProcedimentoValidation<RegisterNewSituacaoProcedimentoCommand>
    {
        public RegisterNewSituacaoProcedimentoCommandValidation()
        {
            ValidateDataRelatorio();
            ValidateObservacao();
            ValidateProcedimentoId();
            ValidateSituacaoId();
            ValidateSituacaoTipoId();
        }
    }
}
