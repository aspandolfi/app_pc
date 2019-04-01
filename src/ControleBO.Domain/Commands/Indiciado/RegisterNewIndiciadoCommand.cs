using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewIndiciadoCommand : IndiciadoCommand
    {
        public RegisterNewIndiciadoCommand(string apelido, PessoaCommand pessoaCommand, int procedimentoId)
        {
            Apelido = apelido;
            PessoaCommand = pessoaCommand;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewIndiciadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
