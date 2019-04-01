using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveProcedimentoCommandValidation : ProcedimentoValidation<RemoveProcedimentoCommand>
    {
        public RemoveProcedimentoCommandValidation()
        {
            ValidateId();
        }
    }
}
