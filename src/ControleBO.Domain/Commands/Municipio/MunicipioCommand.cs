using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class MunicipioCommand : Command
    {
        public int Id { get; protected set; }

        public string Nome { get; protected set; }

        public string UF { get; protected set; }

        public string CEP { get; protected set; }
    }
}
