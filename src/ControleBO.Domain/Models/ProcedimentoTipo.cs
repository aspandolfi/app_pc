using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class ProcedimentoTipo : Entity
    {
        public ProcedimentoTipo(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }

        protected ProcedimentoTipo() { }

        public string Sigla { get; set; }

        public string Descricao { get; set; }
    }
}
