using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class UnidadePolicial : Entity
    {
        public UnidadePolicial(string codigo, string sigla, string descricao, string codigoCargoQO = null)
        {
            Codigo = codigo;
            Sigla = sigla;
            Descricao = descricao;
            CodigoCargoQO = codigoCargoQO;
        }

        public UnidadePolicial(int id, string codigo, string sigla, string descricao, string codigoCargoQO = null)
            : this(codigo, sigla, descricao, codigoCargoQO)
        {
            Id = id;
        }

        protected UnidadePolicial() { }

        public string Codigo { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public string CodigoCargoQO { get; set; }
    }
}
