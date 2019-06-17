using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewMovimentacaoCommand : MovimentacaoCommand
    {
        public RegisterNewMovimentacaoCommand(string destino, DateTime data, DateTime? retornouEm, int procedimentoId)
        {
            Destino = destino;
            Data = data;
            RetornouEm = retornouEm;
            ProcedimentoId = procedimentoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewMovimentacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
