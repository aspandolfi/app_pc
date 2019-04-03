using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateArtigoCommand : ArtigoCommand
    {
        public UpdateArtigoCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateArtigoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
