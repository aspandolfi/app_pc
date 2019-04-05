using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveVaraCriminalCommand : VaraCriminalCommand
    {
        public RemoveVaraCriminalCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVaraCriminalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
