using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateArtigoCommandValidation : ArtigoValidation<UpdateArtigoCommand>
    {
        public UpdateArtigoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
