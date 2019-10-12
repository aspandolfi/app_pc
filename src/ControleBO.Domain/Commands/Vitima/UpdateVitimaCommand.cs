using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdateVitimaCommand : VitimaCommand
    {
        public UpdateVitimaCommand(int id, string email, int procedimentoId, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, string telefone, int? municipioId)
        {
            Id = id;
            Email = email;
            ProcedimentoId = procedimentoId;
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            MunicipioId = municipioId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateVitimaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
