using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class AssuntoCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }
    }
}
