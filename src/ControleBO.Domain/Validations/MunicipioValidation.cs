﻿using ControleBO.Domain.Commands;
using FluentValidation;

namespace ControleBO.Domain.Validations
{
    public abstract class MunicipioValidation<T> : AbstractValidator<T> where T : MunicipioCommand
    {
        protected void ValidateNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu o Nome.")
                .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateUf()
        {
            RuleFor(x => x.UF)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriu o UF.")
                .Length(2, 2).WithMessage("O UF deve ter 2 caracteres.");
        }

        protected void ValidateCep()
        {
            When(x => !string.IsNullOrEmpty(x.CEP), CepValidator);
        }

        private void CepValidator()
        {
            RuleFor(x => x.CEP)
                .Length(9, 9).WithMessage("O CEP deve ter 9 caracteres.");
        }
    }
}
