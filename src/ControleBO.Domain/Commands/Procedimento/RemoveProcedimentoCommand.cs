using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveProcedimentoCommand : ProcedimentoCommand
    {
        public RemoveProcedimentoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProcedimentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
