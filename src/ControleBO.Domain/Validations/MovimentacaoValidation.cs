using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public abstract class MovimentacaoValidation<T> : AbstractValidator<T> where T : MovimentacaoCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }

        protected void ValidateDestino()
        {
            RuleFor(x => x.Destino)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu o Destino.")
                .Length(2, 200).WithMessage("O destino deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateData()
        {
            RuleFor(x => x.Data)
                .GreaterThan(DateTime.Now.AddDays(-1)).WithMessage($"A data deve ser igual a hoje {DateTime.Today.ToString("dd/MM/yyyy")}")
                .LessThan(DateTime.Now.AddDays(-1)).WithMessage($"A data deve ser igual a hoje {DateTime.Today.ToString("dd/MM/yyyy")}");
        }

        protected void ValidateProcedimentoId()
        {
            RuleFor(x => x.ProcedimentoId)
                .GreaterThan(0).WithMessage("O número de Procedimento não existe.");
        }

        protected void ValidateRetornouEm()
        {
            When(x => x.RetornouEm.HasValue, RetornouEmValidator);
        }

        private void RetornouEmValidator()
        {
            RuleFor(x => x.RetornouEm)
                .GreaterThan(x => x.Data).WithMessage("A data de retorno deve ser maior que a data de registro.");
        }
    }
}
