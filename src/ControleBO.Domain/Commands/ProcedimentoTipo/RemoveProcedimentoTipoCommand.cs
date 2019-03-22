using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveProcedimentoTipoCommand : ProcedimentoTipoCommand
    {
        public RemoveProcedimentoTipoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProcedimentoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
