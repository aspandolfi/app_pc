using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class UnidadePolicialCommand : Command
    {
        public int Id { get; protected set; }

        public string Codigo { get; protected set; }

        public string Sigla { get; protected set; }

        public string Descricao { get; protected set; }

        public string CodigoCargoQO { get; protected set; }
    }
}
