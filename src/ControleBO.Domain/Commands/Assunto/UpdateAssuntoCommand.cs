using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateAssuntoCommand : AssuntoCommand
    {
        public UpdateAssuntoCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
