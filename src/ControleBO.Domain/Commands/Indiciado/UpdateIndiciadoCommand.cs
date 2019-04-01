using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateIndiciadoCommand : IndiciadoCommand
    {
        public UpdateIndiciadoCommand(int id, string apelido, PessoaCommand pessoaCommand, int procedimentoId)
        {
            Id = id;
            Apelido = apelido;
            PessoaCommand = pessoaCommand;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateIndiciadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
