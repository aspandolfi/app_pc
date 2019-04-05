using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class UpdateMunicipioCommand : MunicipioCommand
    {
        public UpdateMunicipioCommand(int id, string nome, string uf, string cep)
        {
            Id = id;
            Nome = nome;
            UF = uf;
            CEP = cep;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMunicipioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
