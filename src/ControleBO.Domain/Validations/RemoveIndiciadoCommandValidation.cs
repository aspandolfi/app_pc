using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveIndiciadoCommandValidation : IndiciadoValidation<RemoveIndiciadoCommand>
    {
        public RemoveIndiciadoCommandValidation()
        {
            ValidateId();
        }
    }
}
