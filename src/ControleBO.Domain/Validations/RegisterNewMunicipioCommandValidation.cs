using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewMunicipioCommandValidation : MunicipioValidation<RegisterNewMunicipioCommand>
    {
        public RegisterNewMunicipioCommandValidation()
        {
            ValidateNome();
            ValidateCep();
            ValidateUf();
        }
    }
}
