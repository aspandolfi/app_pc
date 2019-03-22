using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewProcedimentoTipoCommandValidation : ProcedimentoTipoValidation<RegisterNewProcedimentoTipoCommand>
    {
        public RegisterNewProcedimentoTipoCommandValidation()
        {
            ValidateSigla();
            ValidateDescricao();
        }
    }
}
