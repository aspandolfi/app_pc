using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateSituacaoCommand : SituacaoCommand
    {
        public UpdateSituacaoCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateSituacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
