using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveUnidadePolicialCommandValidation : UnidadePolicialValidation<RemoveUnidadePolicialCommand>
    {
        public RemoveUnidadePolicialCommandValidation()
        {
            ValidateId();
        }
    }
}
