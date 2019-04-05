using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateVaraCriminalCommand : VaraCriminalCommand
    {
        public UpdateVaraCriminalCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateVaraCriminalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
