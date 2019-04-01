using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemovePessoaCommand : PessoaCommand
    {
        public RemovePessoaCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemovePessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
