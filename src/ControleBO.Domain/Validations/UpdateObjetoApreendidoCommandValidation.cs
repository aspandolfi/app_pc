using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateObjetoApreendidoCommandValidation : ObjetoApreendidoValidation<UpdateObjetoApreendidoCommand>
    {
        public UpdateObjetoApreendidoCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
            ValidateLocal();
            ValidateProcedimentoId();
        }
    }
}
