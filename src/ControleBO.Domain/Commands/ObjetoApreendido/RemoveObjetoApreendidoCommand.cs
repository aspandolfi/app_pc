using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RemoveObjetoApreendidoCommand : ObjetoApreendidoCommand
    {
        public RemoveObjetoApreendidoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveObjetoApreendidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
