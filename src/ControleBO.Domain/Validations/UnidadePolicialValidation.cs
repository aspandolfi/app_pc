using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public abstract class UnidadePolicialValidation<T> : AbstractValidator<T> where T : UnidadePolicialCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID não é válido.");
        }

        protected void ValidateCodigo()
        {
            RuleFor(x => x.Sigla)
                .NotEmpty().WithMessage("O campo Código deve estar preenchido.")
                .Length(1, 50).WithMessage("O campo código deve ter no mínimo 1 e no máximo 50 caracteres.");
        }

        protected void ValidateSigla()
        {
            RuleFor(x => x.Sigla)
                .NotEmpty().WithMessage("O campo Sigla deve estar preenchido.")
                .Length(1, 10).WithMessage("O campo sigla deve ter no mínimo 1 e no máximo 10 caracteres.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo Descrição deve estar preenchido.")
                .Length(1, 150).WithMessage("O campo Descrição deve ter no mínimo 1 e no máximo 150 caracteres.");
        }
    }
}
