using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewUnidadePolicialCommand : UnidadePolicialCommand
    {
        public RegisterNewUnidadePolicialCommand(string codigo, string sigla, string descricao, string codigoCargoQO = null)
        {
            Codigo = codigo;
            Sigla = sigla;
            Descricao = descricao;
            CodigoCargoQO = codigoCargoQO;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUnidadePolicialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
