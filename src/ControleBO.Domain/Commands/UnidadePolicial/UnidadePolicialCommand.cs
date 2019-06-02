using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class UnidadePolicialCommand : Command
    {
        private string _codigo;
        private string _sigla;
        private string _descricao;
        private string _codigoCargoQO;

        public int Id { get; protected set; }

        public string Codigo
        {
            get
            {
                return _codigo;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _codigo = value.Trim();
                }
            }
        }

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

        public string CodigoCargoQO
        {
            get
            {
                return _codigoCargoQO;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _codigoCargoQO = value.Trim();
                }
            }
        }
    }
}
