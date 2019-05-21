using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class ObjetoApreendidoCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }

        public string Local { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
