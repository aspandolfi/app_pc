using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdateObjetoApreendidoCommand : ObjetoApreendidoCommand
    {
        public UpdateObjetoApreendidoCommand(int id, string descricao, string local, int procedimentoId, DateTime? dataApreensao)
        {
            Id = id;
            Descricao = descricao;
            Local = local;
            ProcedimentoId = procedimentoId;
            DataApreensao = dataApreensao;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateObjetoApreendidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
