using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewSituacaoCommandValidation : SituacaoValidation<RegisterNewSituacaoCommand>
    {
        public RegisterNewSituacaoCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
