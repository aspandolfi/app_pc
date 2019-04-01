using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemoveObjetoApreendidoCommandValidation : ObjetoApreendidoValidation<RemoveObjetoApreendidoCommand>
    {
        public RemoveObjetoApreendidoCommandValidation()
        {
            ValidateId();
        }
    }
}
