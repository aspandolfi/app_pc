using ControleBO.Domain.Core.Models;
using System.Collections.Generic;

namespace ControleBO.Domain.Models
{
    public class Situacao : Entity
    {
        public Situacao(string descricao)
        {
            Descricao = descricao;
            Tipos = new HashSet<SituacaoTipo>();
        }

        public Situacao(int id, string descricao)
            : this(descricao)
        {
            Id = id;
        }

        protected Situacao() { }

        public string Descricao { get; set; }

        public virtual ICollection<SituacaoTipo> Tipos { get; set; }
    }
}
