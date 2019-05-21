using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveUnidadePolicialCommand : UnidadePolicialCommand
    {
        public RemoveUnidadePolicialCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveUnidadePolicialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
