namespace ControleBO.Domain.Queries
{
    public class EstatisticaAssuntoQuery
    {
        public string Assunto { get; set; }

        public int EmAndamento { get; set; }

        public int NaJustica { get; set; }

        public int Relatado { get; set; }

        public int Outro { get; set; }

        public int OutraUniPol { get; set; }

        public int Total
        {
            get
            {
                return EmAndamento + NaJustica + Relatado + OutraUniPol + Outro;
            }
        }
    }
}
