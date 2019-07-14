using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateSituacaoTipoCommandValidation : SituacaoTipoValidation<UpdateSituacaoTipoCommand>
    {
        public UpdateSituacaoTipoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
            ValidateSituacaoId();
        }
    }
}
