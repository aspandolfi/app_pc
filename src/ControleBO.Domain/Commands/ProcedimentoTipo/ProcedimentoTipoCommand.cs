using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class ProcedimentoTipoCommand : Command
    {
        private string _sigla;
        private string _descricao;

        public int Id { get; protected set; }

        public string Sigla
        {
            get
            {
                return _sigla;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _sigla = value.Trim();
                }
            }
        }

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
    }
}
