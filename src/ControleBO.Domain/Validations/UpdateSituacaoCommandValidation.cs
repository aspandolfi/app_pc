using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateSituacaoCommandValidation : SituacaoValidation<UpdateSituacaoCommand>
    {
        public UpdateSituacaoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
