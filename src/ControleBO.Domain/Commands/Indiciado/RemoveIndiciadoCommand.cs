using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveIndiciadoCommand : IndiciadoCommand
    {
        public RemoveIndiciadoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveIndiciadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
