using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public abstract class ObjetoApreendidoValidation<T> : AbstractValidator<T> where T : ObjetoApreendidoCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que o registro existe.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu a Descrição.")
                .Length(2, 200).WithMessage("A Descrição deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateProcedimentoId()
        {
            RuleFor(x => x.ProcedimentoId)
                .GreaterThan(0).WithMessage("O número de Procedimento não existe.");
        }

        protected void ValidateLocal()
        {
            When(x => !string.IsNullOrEmpty(x.Local), LocalValidator);
        }

        private void LocalValidator()
        {
            RuleFor(x => x.Local)
                .Length(2, 150).WithMessage("O Local deve ter entre 2 e 150 caracteres.");
        }
    }
}
