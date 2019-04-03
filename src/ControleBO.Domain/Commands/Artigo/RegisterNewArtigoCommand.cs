using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewArtigoCommand : ArtigoCommand
    {
        public RegisterNewArtigoCommand(string descricao)
        {
            Descricao = Descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewArtigoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
