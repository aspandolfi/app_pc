using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveSituacaoTipoCommandValidation : SituacaoTipoValidation<RemoveSituacaoTipoCommand>
    {
        public RemoveSituacaoTipoCommandValidation()
        {
            ValidateId();
        }
    }
}
