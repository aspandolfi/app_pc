using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands.UnidadePolicial
{
    public abstract class UnidadePolcialCommand : Command
    {
        public int Id { get; protected set; }

        public string Codigo { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public string CodigoCargoQO { get; set; }
    }
}
