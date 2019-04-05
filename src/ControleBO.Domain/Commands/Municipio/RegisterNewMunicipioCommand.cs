using ControleBO.Domain.Validations;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewMunicipioCommand : MunicipioCommand
    {
        public RegisterNewMunicipioCommand(string nome, string uf, string cep)
        {
            Nome = nome;
            UF = uf;
            CEP = cep;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewMunicipioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
