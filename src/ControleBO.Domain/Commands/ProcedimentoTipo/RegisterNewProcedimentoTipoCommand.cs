using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewProcedimentoTipoCommand : ProcedimentoTipoCommand
    {
        public RegisterNewProcedimentoTipoCommand(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProcedimentoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
