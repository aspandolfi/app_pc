using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveMunicipioCommand : MunicipioCommand
    {
        public RemoveMunicipioCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveMunicipioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
