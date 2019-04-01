using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RemovePessoaCommandValidation : PessoaValidation<RemovePessoaCommand>
    {
        public RemovePessoaCommandValidation()
        {
            ValidateId();
        }
    }
}
