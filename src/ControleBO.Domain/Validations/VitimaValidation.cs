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

        protected void ValidateMunicipio()
        {
            When(x => x.MunicipioId.HasValue, () =>
             {
                 RuleFor(x => x.MunicipioId)
                .GreaterThan(0).WithMessage("Por favor verifique se o município existe no sistema.");
             });
        }

        protected void ValidateNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu o Apelido.")
                .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateNomeMae()
        {
            When(x => !string.IsNullOrEmpty(x.NomeMae), NomeMaeValidator);
        }

        private void NomeMaeValidator()
        {
            RuleFor(x => x.NomeMae)
                .Length(2, 200).WithMessage("O nome da Mãe deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateNomePai()
        {
            When(x => !string.IsNullOrEmpty(x.NomePai), NomePaiValidator);
        }

        private void NomePaiValidator()
        {
            RuleFor(x => x.NomePai)
                .Length(2, 200).WithMessage("O nome do Pai deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateDataNascimento()
        {
            When(x => x.DataNascimento.HasValue, () =>
            {
                RuleFor(x => x.DataNascimento)
                .GreaterThan(new DateTime(1920, 1, 1)).WithMessage("A data de nascimento está incorreta.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser menor que hoje.");
            });
        }

        protected void ValidateTelefone()
        {
            RuleFor(x => x.Telefone)
                .MaximumLength(15).WithMessage("O número de telefone deve ter no máximo 15 caracteres.");
        }
    }
}
