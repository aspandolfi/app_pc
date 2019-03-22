using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateProcedimentoTipoCommandValidation : ProcedimentoTipoValidation<UpdateProcedimentoTipoCommand>
    {
        public UpdateProcedimentoTipoCommandValidation()
        {
            ValidateId();
            ValidateSigla();
            ValidateDescricao();
        }
    }
}
