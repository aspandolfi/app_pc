using ControleBO.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
