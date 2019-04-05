using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveMunicipioCommandValidation : MunicipioValidation<RemoveMunicipioCommand>
    {
        public RemoveMunicipioCommandValidation()
        {
            ValidateId();
        }
    }
}
