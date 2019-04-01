using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewPessoaCommandValidation : PessoaValidation<RegisterNewPessoaCommand>
    {
        public RegisterNewPessoaCommandValidation()
        {
            ValidateNome();
            ValidateNomeMae();
            ValidateNomePai();
            ValidateDataNascimento();
            ValidateTelefone();
            ValidateMunicipio();
        }
    }
}
