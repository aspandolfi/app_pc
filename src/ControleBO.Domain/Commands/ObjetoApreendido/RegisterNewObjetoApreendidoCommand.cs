using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewObjetoApreendidoCommand : ObjetoApreendidoCommand
    {
        public RegisterNewObjetoApreendidoCommand(string descricao, string local, int procedimentoId)
        {
            Descricao = descricao;
            Local = local;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewObjetoApreendidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
