using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class ArtigoCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }
    }
}
