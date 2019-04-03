using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveArtigoCommandValidation : ArtigoValidation<RemoveArtigoCommand>
    {
        public RemoveArtigoCommandValidation()
        {
            ValidateId();
        }
    }
}
