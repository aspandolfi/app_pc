using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewUnidadePolicialCommandValidation : UnidadePolicialValidation<RegisterNewUnidadePolicialCommand>
    {
        public RegisterNewUnidadePolicialCommandValidation()
        {
            ValidateCodigo();
            ValidateDescricao();
            ValidateSigla();
        }
    }
}
