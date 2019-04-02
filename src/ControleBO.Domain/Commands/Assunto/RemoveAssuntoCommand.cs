using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveAssuntoCommand : AssuntoCommand
    {
        public RemoveAssuntoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
