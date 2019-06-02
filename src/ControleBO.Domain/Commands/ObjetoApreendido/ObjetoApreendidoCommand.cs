using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class ObjetoApreendidoCommand : Command
    {
        private string _descricao;
        private string _local;

        public int Id { get; protected set; }

        public string Descricao
        {
            get
            {
                return _descricao;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _descricao = value.Trim();
                }
            }
        }

        public string Local
        {
            get
            {
                return _local;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _local = value.Trim();
                }
            }
        }

        public int ProcedimentoId { get; protected set; }
    }
}
