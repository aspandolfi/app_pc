using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public abstract class IndiciadoValidation<T> : AbstractValidator<T> where T : IndiciadoCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor verifique se é um ID válido.");
        }

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

        protected void ValidateMunicipio()
        {
            //RuleFor(x => x.MunicipioId)
            //    .GreaterThan(0).WithMessage("Por favor verifique se o município existe no sistema.");
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
