using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveSituacaoCommand : SituacaoCommand
    {
        public RemoveSituacaoCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveSituacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
