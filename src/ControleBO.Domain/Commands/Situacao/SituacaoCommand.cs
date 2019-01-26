using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands.Situacao
{
    public abstract class SituacaoCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }
    }
}
