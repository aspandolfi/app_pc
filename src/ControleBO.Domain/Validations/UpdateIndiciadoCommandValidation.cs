using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateIndiciadoCommandValidation : IndiciadoValidation<UpdateIndiciadoCommand>
    {
        public UpdateIndiciadoCommandValidation()
        {
            ValidateApelido();
            ValidatePessoa();
            ValidateProcedimentoId();
        }
    }
}
