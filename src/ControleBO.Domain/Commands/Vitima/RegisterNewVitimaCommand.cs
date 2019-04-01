using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewVitimaCommand : VitimaCommand
    {
        public RegisterNewVitimaCommand(string email, PessoaCommand pessoaCommand, int procedimentoId)
        {
            Email = email;
            PessoaCommand = pessoaCommand;
            ProcedimentoId = procedimentoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewVitimaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
