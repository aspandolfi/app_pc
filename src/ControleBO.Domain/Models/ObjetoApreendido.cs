using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public class ObjetoApreendido : Entity
    {
        public ObjetoApreendido(string descricao, string local, Procedimento procedimento, DateTime? dataApreensao)
        {
            Descricao = descricao;
            Local = local;
            Procedimento = procedimento;
            DataApreensao = dataApreensao;
        }

        public ObjetoApreendido(int id, string descricao, string local, Procedimento procedimento, DateTime? dataApreensao)
            : this(descricao, local, procedimento, dataApreensao)
        {
            Id = id;
        }

        protected ObjetoApreendido() { }

        public string Descricao { get; set; }

        public string Local { get; set; }

        public DateTime? DataApreensao { get; set; }

        public int ProcedimentoId { get; set; }

        public virtual Procedimento Procedimento { get; set; }
    }
}
