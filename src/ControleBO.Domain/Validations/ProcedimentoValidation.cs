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
            When(x => !string.IsNullOrEmpty(x.BoletimUnificado), () =>
             {
                 RuleFor(x => x.BoletimUnificado)
                 .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Boletim Unificado.");
             });
        }

        protected void ValidateBoletimOcorrencia()
        {
            When(x => !string.IsNullOrEmpty(x.BoletimOcorrencia), () =>
             {
                 RuleFor(x => x.BoletimOcorrencia)
                 .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Boletim de Ocorrência.");
             });
        }

        protected void ValidateNumeroProcessual()
        {
            When(x => !string.IsNullOrEmpty(x.NumeroProcessual), () =>
             {
                 RuleFor(x => x.NumeroProcessual)
                 .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo Número Processual.")
                 .MaximumLength(30).WithMessage("Por favor verifique se o número processual tem menos de 30 caracteres.");
             });
        }

        protected void ValidateGampes()
        {
            When(x => !string.IsNullOrEmpty(x.Gampes), () =>
             {
                 RuleFor(x => x.Gampes)
                 .NotEmpty().WithMessage("Por favor tenha certeza que você inseriou o campo GAMPES.");
             });
        }

        protected void ValidateTipoProcedimento()
        {
            When(x => x.TipoProcedimentoId > 0, () =>
            {
                RuleFor(x => x.TipoProcedimentoId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que o Tipo de Procedimento é válido.");
            });
        }

        protected void ValidateVaraCriminal()
        {
            When(x => x.VaraCriminalId > 0, () =>
            {
                RuleFor(x => x.VaraCriminalId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que a Vara Criminal é válida.");
            });
        }

        protected void ValidateComarca()
        {
            When(x => x.ComarcaId > 0, () =>
             {
                 RuleFor(x => x.ComarcaId)
                 .GreaterThan(0).WithMessage("Por favor tenha certeza que a Comarca é válida.");
             });
        }

        protected void ValidateAssunto()
        {
            When(x => x.AssuntoId > 0, () =>
             {
                 RuleFor(x => x.AssuntoId)
                 .GreaterThan(0).WithMessage("Por favor tenha certeza que o Assunto é válido.");
             });
        }

        protected void ValidateArtigo()
        {
            When(x => x.ArtigoId > 0, () =>
             {
                 RuleFor(x => x.ArtigoId)
                 .GreaterThan(0).WithMessage("Por favor tenha certeza que o Artigo é válido.");
             });
        }

        protected void ValidateDelegaciaOrigem()
        {
            When(x => x.DelegaciaOrigemId > 0, () =>
              {
                  RuleFor(x => x.DelegaciaOrigemId)
                .GreaterThan(0).WithMessage("Por favor tenha certeza que a Delegacia de Origem é válida.");
              });
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
            When(x => x.DataFato.HasValue, () =>
            {
                RuleFor(x => x.DataFato)
                .LessThanOrEqualTo(DateTime.Now.AddHours(23 - DateTime.Now.Hour).AddMinutes(59 - DateTime.Now.Minute)).WithMessage("A Data do Fato deve ser menor ou igual a data de hoje.");
            });
        }

        protected void ValidateDataInstauracao()
        {
            When(x => x.DataInstauracao.HasValue, () =>
            {
                RuleFor(x => x.DataInstauracao)
                .GreaterThanOrEqualTo(x => x.DataFato).WithMessage("A Data do Instauração deve ser maior ou igual que a data do fato.");
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
