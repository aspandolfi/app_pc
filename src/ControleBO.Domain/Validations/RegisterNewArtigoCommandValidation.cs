using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewArtigoCommandValidation : ArtigoValidation<RegisterNewArtigoCommand>
    {
        public RegisterNewArtigoCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
