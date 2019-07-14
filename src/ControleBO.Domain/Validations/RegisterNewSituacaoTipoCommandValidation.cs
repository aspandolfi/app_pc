using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewSituacaoTipoCommandValidation : SituacaoTipoValidation<RegisterNewSituacaoTipoCommand>
    {
        public RegisterNewSituacaoTipoCommandValidation()
        {
            ValidateDescricao();
            ValidateSituacaoId();
        }
    }
}
