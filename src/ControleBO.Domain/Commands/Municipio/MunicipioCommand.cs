using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands
{
    public abstract class MunicipioCommand : Command
    {
        private string _nome;
        private string _uf;
        private string _cep;

        public int Id { get; protected set; }

        public string Nome
        {
            get
            {
                return _nome;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nome = value.Trim();
                }
            }
        }

        public string UF
        {
            get
            {
                return _uf;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _uf = value.Trim();
                }
            }
        }

        public string CEP
        {
            get
            {
                return _cep;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _cep = value.Trim();
                }
            }
        }
    }
}
