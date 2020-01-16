using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewObjetoApreendidoCommand : ObjetoApreendidoCommand
    {
        public RegisterNewObjetoApreendidoCommand(string descricao, string local, int procedimentoId, DateTime? dataApreensao)
        {
            Descricao = descricao;
            Local = local;
            ProcedimentoId = procedimentoId;
            DataApreensao = dataApreensao;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewObjetoApreendidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
