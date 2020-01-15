using ControleBO.Domain.Core.Models;
using System.Collections.Generic;

namespace ControleBO.Domain.Models
{
    public class Situacao : Entity
    {
        public const string NaDelegacia = "NaDelegacia";
        public const string NaJustica = "NaJustica";
        public const string Relatado = "Relatado";
        public const string Outros = "Outros";

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

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<SituacaoTipo> Tipos { get; set; }
    }
}
