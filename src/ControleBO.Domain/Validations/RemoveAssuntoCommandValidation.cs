using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveAssuntoCommandValidation : AssuntoValidation<RemoveAssuntoCommand>
    {
        public RemoveAssuntoCommandValidation()
        {
            ValidateId();
        }
    }
}
