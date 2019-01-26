using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public abstract class ArtigoValidation<T> : AbstractValidator<T> where T : ArtigoCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu a Descrição.")
                .Length(2, 200).WithMessage("A Descrição deve ter entre 2 e 200 caracteres.");
        }
    }
}
