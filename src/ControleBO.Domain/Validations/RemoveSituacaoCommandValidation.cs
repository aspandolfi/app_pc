using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveSituacaoCommandValidation : SituacaoValidation<RemoveSituacaoCommand>
    {
        public RemoveSituacaoCommandValidation()
        {
            ValidateId();
        }
    }
}
