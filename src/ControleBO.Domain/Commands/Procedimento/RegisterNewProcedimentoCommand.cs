using ControleBO.Domain.Validations;
using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewProcedimentoCommand : ProcedimentoCommand
    {
        public RegisterNewProcedimentoCommand(string boletimUnificado,
                                              string boletimOcorrencia,
                                              string numeroProcessual,
                                              string gampes,
                                              string anexos,
                                              string localFato,
                                              DateTime dataFato,
                                              DateTime? dataInstauracao,
                                              string tipoCriminal,
                                              string andamentoProcessual,
                                              int tipoProcedimentoId,
                                              int varaCriminalId,
                                              int comarcaId,
                                              int assuntoId,
                                              int artigoId,
                                              int delegaciaOrigemId)
        {
            BoletimUnificado = boletimUnificado;
            BoletimOcorrencia = boletimOcorrencia;
            NumeroProcessual = numeroProcessual;
            Gampes = gampes;
            Anexos = anexos;
            LocalFato = localFato;
            DataFato = dataFato;
            DataInstauracao = dataInstauracao;
            TipoCriminal = tipoCriminal;
            AndamentoProcessual = andamentoProcessual;
            TipoProcedimentoId = tipoProcedimentoId;
            VaraCriminalId = varaCriminalId;
            ComarcaId = comarcaId;
            AssuntoId = assuntoId;
            ArtigoId = artigoId;
            DelegaciaOrigemId = delegaciaOrigemId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProcedimentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
