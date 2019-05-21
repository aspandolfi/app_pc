using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateUnidadePolicialCommandValidation : UnidadePolicialValidation<UpdateUnidadePolicialCommand>
    {
        public UpdateUnidadePolicialCommandValidation()
        {
            ValidateId();
            ValidateCodigo();
            ValidateSigla();
            ValidateDescricao();
        }
    }
}
