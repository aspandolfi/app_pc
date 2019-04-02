using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewAssuntoCommandValidation : AssuntoValidation<RegisterNewAssuntoCommand>
    {
        public RegisterNewAssuntoCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
