using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public abstract class SituacaoProcedimentoValidation<T> : AbstractValidator<T> where T : SituacaoProcedimentoCommand
    {
        protected void ValidateObservacao()
        {
            When(x => !string.IsNullOrEmpty(x.Observacao), () =>
            {
                RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu a Observação.")
                .Length(2, 200).WithMessage("A Descrição deve ter entre 2 e 200 caracteres.");
            });
        }

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }

        protected void ValidateProcedimentoId()
        {
            RuleFor(x => x.ProcedimentoId)
                .GreaterThan(0).WithMessage("Por favor verifique se é um procedimento válido.");
        }

        protected void ValidateSituacaoId()
        {
            RuleFor(x => x.SituacaoId)
                .GreaterThan(0).WithMessage("Por favor verifique se é uma situação válida.");
        }

        protected void ValidateSituacaoTipoId()
        {
            When(x => x.SituacaoTipoId.HasValue, () =>
             {
                 RuleFor(x => x.SituacaoTipoId)
                 .GreaterThan(0).WithMessage("Por favor verifique se é um tipo válido.");
             });
        }

        protected void ValidateDataRelatorio()
        {
            When(x => x.DataRelatorio.HasValue, () =>
            {
                RuleFor(x => x.DataRelatorio)
                .LessThan(DateTime.Now.AddDays(1)).WithMessage("Por favor, a data do relatório não pode ser maior que a data de hoje.");
            });
        }
    }
}
