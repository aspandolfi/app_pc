using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public abstract class VitimaValidation<T> : AbstractValidator<T> where T : VitimaCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }

        protected void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
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
