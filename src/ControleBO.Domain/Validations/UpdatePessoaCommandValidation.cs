using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdatePessoaCommandValidation : PessoaValidation<UpdatePessoaCommand>
    {
        public UpdatePessoaCommandValidation()
        {
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
