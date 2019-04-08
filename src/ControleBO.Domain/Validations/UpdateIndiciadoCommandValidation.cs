using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateIndiciadoCommandValidation : IndiciadoValidation<UpdateIndiciadoCommand>
    {
        public UpdateIndiciadoCommandValidation()
        {
            ValidateApelido();
            ValidateProcedimentoId();
            ValidateNome();
            ValidateNomeMae();
            ValidateNomePai();
            ValidateDataNascimento();
            ValidateTelefone();
            ValidateMunicipio();
            ValidateId();
        }
    }
}
