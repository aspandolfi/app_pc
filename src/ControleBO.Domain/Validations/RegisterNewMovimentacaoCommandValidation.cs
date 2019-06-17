using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewMovimentacaoCommandValidation : MovimentacaoValidation<RegisterNewMovimentacaoCommand>
    {
        public RegisterNewMovimentacaoCommandValidation()
        {
            ValidateDestino();
            ValidateData();
            ValidateProcedimentoId();
        }
    }
}
