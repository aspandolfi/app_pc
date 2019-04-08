using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class UpdateIndiciadoCommand : IndiciadoCommand
    {
        public UpdateIndiciadoCommand(int id, string apelido, int procedimentoId, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, int? idade, string telefone, int municipioId)
        {
            Id = id;
            Apelido = apelido;
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
            ValidationResult = new UpdateIndiciadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
