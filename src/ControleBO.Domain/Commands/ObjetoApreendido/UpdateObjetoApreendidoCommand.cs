using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateObjetoApreendidoCommand : ObjetoApreendidoCommand
    {
        public UpdateObjetoApreendidoCommand(int id, string descricao, string local, int procedimentoId)
        {
            Id = id;
            Descricao = descricao;
            Local = local;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateObjetoApreendidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
