using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateUnidadePolicialCommand : UnidadePolicialCommand
    {
        public UpdateUnidadePolicialCommand(int id, string codigo, string sigla, string descricao, string codigoCargoQO = null)
        {
            Id = id;
            Codigo = codigo;
            Sigla = sigla;
            Descricao = descricao;
            CodigoCargoQO = codigoCargoQO;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateUnidadePolicialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
