namespace ControleBO.Domain.Commands
{
    public class UpdateObjetoApreedidoCommand : ObjetoApreendidoCommand
    {
        public UpdateObjetoApreedidoCommand(int id, string descricao, string local, int procedimentoId)
        {
            Id = id;
            Descricao = descricao;
            Local = local;
            ProcedimentoId = procedimentoId;
        }
        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
