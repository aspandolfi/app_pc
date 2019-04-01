using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewPessoaCommand : PessoaCommand
    {
        public RegisterNewPessoaCommand(string nome,
                                        string nomePai,
                                        string nomeMae,
                                        DateTime? dataNascimento,
                                        string telefone,
                                        int municipioId)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            MunicipioId = municipioId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
