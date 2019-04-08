using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewIndiciadoCommandValidation : IndiciadoValidation<RegisterNewIndiciadoCommand>
    {
        public RegisterNewIndiciadoCommandValidation()
        {
            ValidateApelido();
            ValidateProcedimentoId();
            ValidateNome();
            ValidateNomeMae();
            ValidateNomePai();
            ValidateDataNascimento();
            ValidateTelefone();
            ValidateMunicipio();
        }
    }
}
