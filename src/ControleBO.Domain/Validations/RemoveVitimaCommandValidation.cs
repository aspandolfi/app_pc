using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveVitimaCommandValidation : VitimaValidation<RemoveVitimaCommand>
    {
        public RemoveVitimaCommandValidation()
        {
            ValidateId();
        }
    }
}
