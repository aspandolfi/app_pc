using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveSituacaoProcedimentoCommand : SituacaoProcedimentoCommand
    {
        public RemoveSituacaoProcedimentoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveSituacaoProcedimentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
