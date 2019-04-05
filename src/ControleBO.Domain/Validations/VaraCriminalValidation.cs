using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public class VaraCriminalValidation<T> : AbstractValidator<T> where T : VaraCriminalCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu a Vara Criminal.")
                .Length(2, 200).WithMessage("O assunto deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }
    }
}
