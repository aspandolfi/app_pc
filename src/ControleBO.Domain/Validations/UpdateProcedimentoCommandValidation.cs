using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class UpdateProcedimentoCommandValidation : ProcedimentoValidation<UpdateProcedimentoCommand>
    {
        public UpdateProcedimentoCommandValidation()
        {
            ValidateId();
            ValidateBoletimUnificado();
            ValidateBoletimOcorrencia();
            ValidateNumeroProcessual();
            ValidateGampes();
            ValidateAnexos();
            ValidateLocalFato();
            ValidateDataFato();
            ValidateDataInstauracao();
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
