using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateSituacaoTipoCommand : SituacaoTipoCommand
    {
        public UpdateSituacaoTipoCommand(int id, string descricao, int situacaoId)
        {
            Id = id;
            Descricao = descricao;
            SituacaoId = situacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSituacaoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
