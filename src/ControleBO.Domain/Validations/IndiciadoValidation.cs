using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public abstract class IndiciadoValidation<T> : AbstractValidator<T> where T : IndiciadoCommand
    {
        protected void ValidateApelido()
        {
            When(x => !string.IsNullOrEmpty(x.Apelido), () =>
            {
                RuleFor(x => x.Apelido)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu o Apelido.")
                .Length(2, 200).WithMessage("O assunto deve ter entre 2 e 200 caracteres.");
            });
        }

        protected void ValidateProcedimentoId()
        {
            RuleFor(x => x.ProcedimentoId)
                .NotEqual(0).WithMessage("Por favor verique se o procedimento existe.")
                .GreaterThan(0).WithMessage("O número de Procedimento não existe.");
        }

        protected void ValidatePessoa()
        {
            When(x => x.PessoaCommand != null, PessoaValidator);
        }

        private void PessoaValidator()
        {
            RuleFor(x => x.PessoaCommand.Nome)
                .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");

            RuleFor(x => x.PessoaCommand.NomeMae)
                .Length(2, 200).WithMessage("O nome da Mãe deve ter entre 2 e 200 caracteres.");

            RuleFor(x => x.PessoaCommand.NomePai)
                .Length(2, 200).WithMessage("O nome do Pai deve ter entre 2 e 200 caracteres.");

            When(x => x.PessoaCommand.DataNascimento.HasValue, () =>
            {
                RuleFor(x => x.PessoaCommand.DataNascimento)
                .GreaterThan(new DateTime(1920, 1, 1))
                .LessThan(DateTime.Now);
            });

            RuleFor(x => x.PessoaCommand.Telefone)
                .MaximumLength(15);
        }
    }
}
