using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdateMovimentacaoCommand : MovimentacaoCommand
    {
        public UpdateMovimentacaoCommand(int id, string destino, DateTime data, DateTime? retornouEm, int procedimentoId)
        {
            Id = id;
            Destino = destino;
            Data = data;
            RetornouEm = retornouEm;
            ProcedimentoId = procedimentoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMovimentacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
