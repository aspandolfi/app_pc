using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class Municipio : Entity
    {
        public Municipio(string nome, string uf, string cep)
        {
            Nome = nome;
            UF = uf;
            CEP = cep;
        }

        public Municipio(int id, string nome, string uf, string cep) : this(nome, uf, cep)
        {
            Id = id;
        }

        protected Municipio() { }

        public string Nome { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }
    }
}
