using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdatePessoaCommand : PessoaCommand
    {
        public UpdatePessoaCommand(int id,
                                   string nome,
                                   string nomePai,
                                   string nomeMae,
                                   DateTime? dataNascimento,
                                   string telefone,
                                   int municipioId)
        {
            Id = id;
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            MunicipioId = municipioId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
