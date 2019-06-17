using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveSituacaoProcedimentoCommandValidation : SituacaoProcedimentoValidation<RemoveSituacaoProcedimentoCommand>
    {
        public RemoveSituacaoProcedimentoCommandValidation()
        {
            ValidateId();
        }
    }
}
