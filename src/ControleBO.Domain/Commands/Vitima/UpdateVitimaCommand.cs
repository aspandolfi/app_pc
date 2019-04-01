using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateVitimaCommand : VitimaCommand
    {
        public UpdateVitimaCommand(int id, string email, PessoaCommand pessoaCommand, int procedimentoId)
        {
            Id = id;
            Email = email;
            PessoaCommand = pessoaCommand;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateVitimaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
