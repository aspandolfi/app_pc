using ControleBO.Domain.Core.Commands;
using System;

namespace ControleBO.Domain.Commands
{
    public abstract class MovimentacaoCommand : Command
    {
        public int Id { get; protected set; }

        public string Destino { get; protected set; }

        public DateTime Data { get; protected set; }

        public DateTime? RetornouEm { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
