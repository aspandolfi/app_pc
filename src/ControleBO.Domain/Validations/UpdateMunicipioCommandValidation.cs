using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateMunicipioCommandValidation : MunicipioValidation<UpdateMunicipioCommand>
    {
        public UpdateMunicipioCommandValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateUf();
            ValidateCep();
        }
    }
}
