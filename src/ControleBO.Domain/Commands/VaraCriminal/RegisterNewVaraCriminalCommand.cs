using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewVaraCriminalCommand : VaraCriminalCommand
    {
        public RegisterNewVaraCriminalCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewVaraCriminalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
