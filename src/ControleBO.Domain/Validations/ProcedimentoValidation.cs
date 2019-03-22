using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public class ProcedimentoValidation<T> : AbstractValidator<T> where T : ProcedimentoCommand
    {
        protected void ValidateBoletimUnificado()
        {
            RuleFor(x => x.BoletimUnificado)
                .NotEmpty();
        }
    }
}
