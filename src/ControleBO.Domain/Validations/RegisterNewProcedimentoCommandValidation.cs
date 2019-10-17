using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewProcedimentoCommandValidation : ProcedimentoValidation<RegisterNewProcedimentoCommand>
    {
        public RegisterNewProcedimentoCommandValidation()
        {
            ValidateBoletimUnificado();
            ValidateBoletimOcorrencia();
            ValidateNumeroProcessual();
            ValidateGampes();
            ValidateAnexos();
            ValidateLocalFato();
            ValidateDataFato();
            ValidateDataInstauracao();
            ValidateTipoCriminal();
            ValidateAndamentoProcessual();
            ValidateTipoProcedimento();
            ValidateVaraCriminal();
            ValidateComarca();
            ValidateAssunto();
            ValidateArtigo();
            ValidateDelegaciaOrigem();
        }
    }
}
