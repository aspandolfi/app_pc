using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateObjetoApreedidoCommandValidation : ObjetoApreendidoValidation<UpdateObjetoApreedidoCommand>
    {
        public UpdateObjetoApreedidoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
            ValidateLocal();
            ValidateProcedimentoId();
        }
    }
}
