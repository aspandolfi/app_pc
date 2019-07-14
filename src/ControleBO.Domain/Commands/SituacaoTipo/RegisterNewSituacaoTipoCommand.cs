using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewSituacaoTipoCommand : SituacaoTipoCommand
    {
        public RegisterNewSituacaoTipoCommand(string descricao, int situacaoId)
        {
            Descricao = descricao;
            SituacaoId = situacaoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewSituacaoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
