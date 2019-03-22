using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveProcedimentoTipoCommandValidation : ProcedimentoTipoValidation<RemoveProcedimentoTipoCommand>
    {
        public RemoveProcedimentoTipoCommandValidation()
        {
            ValidateId();
        }
    }
}
