namespace ControleBO.Domain.Commands
{
    public abstract class IndiciadoCommand : PessoaCommand
    {
        private string _apelido;

        public string Apelido
        {
            get
            {
                return _apelido;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _apelido = value.Trim();
                }
            }
        }

        public int ProcedimentoId { get; protected set; }
    }
}
