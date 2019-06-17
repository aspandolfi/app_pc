using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveMovimentacaoCommand : MovimentacaoCommand
    {
        public RemoveMovimentacaoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveMovimentacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
