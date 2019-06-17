using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewSituacaoCommand : SituacaoCommand
    {
        public RegisterNewSituacaoCommand(string descricao)
        {
            Descricao = descricao;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewSituacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
