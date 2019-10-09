using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewVitimaCommand : VitimaCommand
    {
        public RegisterNewVitimaCommand(string email, int procedimentoId, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, int? municipioId)
        {
            Email = email;
            ProcedimentoId = procedimentoId;
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Idade = idade;
            Telefone = telefone;
            MunicipioId = municipioId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewVitimaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
