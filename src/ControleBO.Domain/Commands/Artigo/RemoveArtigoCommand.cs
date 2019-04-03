using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveArtigoCommand : ArtigoCommand
    {
        public RemoveArtigoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveArtigoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
