using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewVaraCriminalCommandValidation : VaraCriminalValidation<RegisterNewVaraCriminalCommand>
    {
        public RegisterNewVaraCriminalCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
