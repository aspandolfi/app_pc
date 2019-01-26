namespace ControleBO.Domain.Models
{
    public class Municipio
    {
        public Municipio(string nome, string uf, string cep)
        {
            Nome = nome;
            UF = uf;
            CEP = cep;
        }

        protected Municipio() { }

        public string Nome { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }
    }
}
