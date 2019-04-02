using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewAssuntoCommand : AssuntoCommand
    {
        public RegisterNewAssuntoCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
