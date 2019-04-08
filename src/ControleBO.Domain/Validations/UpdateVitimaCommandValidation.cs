using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateVitimaCommandValidation : VitimaValidation<UpdateVitimaCommand>
    {
        public UpdateVitimaCommandValidation()
        {
            ValidateEmail();
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
