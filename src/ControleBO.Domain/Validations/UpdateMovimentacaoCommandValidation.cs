using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateMovimentacaoCommandValidation : MovimentacaoValidation<UpdateMovimentacaoCommand>
    {
        public UpdateMovimentacaoCommandValidation()
        {
            ValidateId();
            ValidateDestino();
            ValidateData();
            ValidateRetornouEm();
            ValidateProcedimentoId();
        }
    }
}
