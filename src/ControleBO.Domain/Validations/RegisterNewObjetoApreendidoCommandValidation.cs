using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewObjetoApreendidoCommandValidation : ObjetoApreendidoValidation<RegisterNewObjetoApreendidoCommand>
    {
        public RegisterNewObjetoApreendidoCommandValidation()
        {
            ValidateDescricao();
            ValidateLocal();
            ValidateProcedimentoId();
        }
    }
}
