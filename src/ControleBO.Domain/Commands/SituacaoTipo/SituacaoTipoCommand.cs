using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands.SituacaoTipo
{
    public abstract class SituacaoTipoCommand : Command
    {
        public int Id { get; protected set; }

        public string Descricao { get; protected set; }

        public int SituacaoId { get; protected set; }
    }
}
