using ControleBO.Domain.Core.Commands;
using System;

namespace ControleBO.Domain.Commands
{
    public abstract class PessoaCommand : Command
    {
        private string _nome;
        private string _nomePai;
        private string _nomeMae;
        private string _telefone;

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

        public string NomePai
        {
            get
            {
                return _nomePai;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nomePai = value.Trim();
                }
            }
        }

        public string NomeMae
        {
            get
            {
                return _nomeMae;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nomeMae = value.Trim();
                }
            }
        }

        public DateTime? DataNascimento { get; protected set; }

        public int? Idade { get; protected set; }

        public string Telefone
        {
            get
            {
                return _telefone;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _telefone = value.Trim();
                }
            }
        }

        public int MunicipioId { get; protected set; }
    }
}
