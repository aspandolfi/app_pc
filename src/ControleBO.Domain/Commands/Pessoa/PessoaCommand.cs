using ControleBO.Domain.Core.Commands;
using System;

namespace ControleBO.Domain.Commands
{
    public abstract class PessoaCommand : Command
    {
        public int Id { get; protected set; }

        public string Nome { get; protected set; }

        public string NomePai { get; protected set; }

        public string NomeMae { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

        public string Telefone { get; protected set; }

        public int MunicipioId { get; protected set; }
    }
}
