using ControleBO.Domain.Commands;
using FluentValidation;
using System;

namespace ControleBO.Domain.Validations
{
    public class ProcedimentoValidation<T> : AbstractValidator<T> where T : ProcedimentoCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que é um registro válido.");
        }

        protected void ValidateBoletimUnificado()
        {
            RuleFor(x => x.BoletimUnificado)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Boletim Unificado.");
        }

        protected void ValidateBoletimOcorrencia()
        {
            RuleFor(x => x.BoletimOcorrencia)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Boletim de Ocorrência.");
        }

        protected void ValidateNumeroProcessual()
        {
            RuleFor(x => x.NumeroProcessual)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Número Processual.");
        }

        protected void ValidateGampes()
        {
            RuleFor(x => x.Gampes)
                .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo GAMPES.");
        }

        protected void ValidateTipoProcedimento()
        {
            RuleFor(x => x.TipoProcedimentoId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que o Tipo de Procedimento é válido.");
        }

        protected void ValidateVaraCriminal()
        {
            RuleFor(x => x.VaraCriminalId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que a Vara Criminal é válida.");
        }

        protected void ValidateComarca()
        {
            RuleFor(x => x.ComarcaId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que a Comarca é válida.");
        }

        protected void ValidateAssunto()
        {
            RuleFor(x => x.AssuntoId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que o Assunto é válido.");
        }

        protected void ValidateArtigo()
        {
            RuleFor(x => x.ArtigoId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que o Artigo é válido.");
        }

        protected void ValidateDelegaciaOrigem()
        {
            RuleFor(x => x.DelegaciaOrigemId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que a Delegacia de Origem é válida.");
        }

        protected void ValidateAnexos()
        {
            When(x => !string.IsNullOrEmpty(x.Anexos), () =>
            {
                RuleFor(x => x.Anexos)
                .Length(2, 250).WithMessage("O campo Anexos deve ter entre 2 e 250 caracteres.");
            });
        }

        protected void ValidateLocalFato()
        {
            When(x => !string.IsNullOrEmpty(x.LocalFato), () =>
            {
                RuleFor(x => x.LocalFato)
                .Length(2, 250).WithMessage("O campo Local do Fato deve ter entre 2 e 250 caracteres.");
            });
        }

        protected void ValidateDataFato()
        {
            RuleFor(x => x.DataFato)
                .LessThan(DateTime.Now).WithMessage("A Data do Fato deve ser menor que a data atual.");
        }

        protected void ValidateTipoCriminal()
        {
            When(x => !string.IsNullOrEmpty(x.TipoCriminal), () =>
            {
                RuleFor(x => x.TipoCriminal)
                .Length(2, 250).WithMessage("O campo Tipo Criminal deve ter entre 2 e 250 caracteres.");
            });
        }

        protected void ValidateAndamentoProcessual()
        {
            When(x => !string.IsNullOrEmpty(x.AndamentoProcessual), () =>
            {
                RuleFor(x => x.AndamentoProcessual)
                .Length(2, 250).WithMessage("O campo Andamento Processual deve ter entre 2 e 250 caracteres.");
            });
        }
    }
}
