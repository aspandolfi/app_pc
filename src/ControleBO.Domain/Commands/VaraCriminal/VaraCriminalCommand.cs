using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands.VaraCriminal
{
    public abstract class VaraCriminalCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }
    }
}
