using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveVaraCriminalCommandValidation : VaraCriminalValidation<RemoveVaraCriminalCommand>
    {
        public RemoveVaraCriminalCommandValidation()
        {
            ValidateId();
        }
    }
}
