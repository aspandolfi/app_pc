using ControleBO.Domain.Core.Commands;
using System;

namespace ControleBO.Domain.Commands
{
    public abstract class SituacaoProcedimentoCommand : Command
    {
        private string _observacao;

        public int Id { get; protected set; }

        public DateTime? DataRelatorio { get; protected set; }

        public string Observacao
        {
            get
            {
                return _observacao;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _observacao = value.Trim();
                }
            }
        }

        public int ProcedimentoId { get; protected set; }

        public int SituacaoId { get; protected set; }

        public int? SituacaoTipoId { get; protected set; }
    }
}
