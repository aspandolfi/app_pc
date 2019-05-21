using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public class Movimentacao : Entity
    {
        public Movimentacao(string destino, DateTime data, Procedimento procedimento)
        {
            Destino = destino;
            Data = data;
            Procedimento = procedimento;
        }

        protected Movimentacao() { }

        public string Destino { get; set; }

        public DateTime Data { get; set; }

        public DateTime? RetornouEm { get; set; }

        public int ProcedimentoId { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
