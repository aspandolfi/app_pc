using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveSituacaoTipoCommand : SituacaoTipoCommand
    {
        public RemoveSituacaoTipoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveSituacaoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
