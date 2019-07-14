using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public abstract class SituacaoTipoValidation<T> : AbstractValidator<T> where T : SituacaoTipoCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu a Descrição.")
                .Length(2, 200).WithMessage("A Descrição deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }

        protected void ValidateSituacaoId()
        {
            RuleFor(x => x.SituacaoId)
                .GreaterThan(0).WithMessage("Por favor verifique se a situação é válida.");
        }
    }
}
