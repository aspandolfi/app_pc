using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateProcedimentoTipoCommand : ProcedimentoTipoCommand
    {
        public UpdateProcedimentoTipoCommand(int id, string sigla, string descricao)
        {
            Id = id;
            Sigla = sigla;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProcedimentoTipoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
