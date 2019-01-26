using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class IndiciadoCommand : Command
    {
        public int Id { get; protected set; }

        public string Apelido { get; protected set; }

        public PessoaCommand PessoaCommand { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
