using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveMovimentacaoCommandValidation : MovimentacaoValidation<RemoveMovimentacaoCommand>
    {
        public RemoveMovimentacaoCommandValidation()
        {
            ValidateId();
        }
    }
}
