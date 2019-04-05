using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateVaraCriminalCommandValidation : VaraCriminalValidation<UpdateVaraCriminalCommand>
    {
        public UpdateVaraCriminalCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
