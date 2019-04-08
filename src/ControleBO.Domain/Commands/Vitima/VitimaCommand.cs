using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class VitimaCommand : PessoaCommand
    {
        public string Email { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
