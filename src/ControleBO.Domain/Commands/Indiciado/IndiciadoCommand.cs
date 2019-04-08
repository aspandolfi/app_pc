namespace ControleBO.Domain.Commands
{
    public abstract class IndiciadoCommand : PessoaCommand
    {
        public string Apelido { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
