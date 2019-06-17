using ControleBO.Domain.Core.Commands;
using System;

namespace ControleBO.Domain.Commands
{
    public abstract class MovimentacaoCommand : Command
    {
        private string _destino;

        public int Id { get; protected set; }

        public string Destino
        {
            get
            {
                return _destino;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _destino = value.Trim();
                }
            }
        }

        public DateTime Data { get; protected set; }

        public DateTime? RetornouEm { get; protected set; }

        public int ProcedimentoId { get; protected set; }
    }
}
