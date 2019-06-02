namespace ControleBO.Domain.Commands
{
    public abstract class VitimaCommand : PessoaCommand
    {
        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _email = value.Trim();
                }
            }
        }

        public int ProcedimentoId { get; protected set; }
    }
}
