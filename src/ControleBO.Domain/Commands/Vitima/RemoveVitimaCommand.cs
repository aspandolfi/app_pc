using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveVitimaCommand : VitimaCommand
    {
        public RemoveVitimaCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveVitimaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
