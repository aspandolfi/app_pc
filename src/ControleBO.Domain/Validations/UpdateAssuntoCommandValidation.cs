using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateAssuntoCommandValidation : AssuntoValidation<UpdateAssuntoCommand>
    {
        public UpdateAssuntoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
