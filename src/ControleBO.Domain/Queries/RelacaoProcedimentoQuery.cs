using System;

namespace ControleBO.Domain.Queries
{
    public class RelacaoProcedimentoQuery
    {
        public int NumeroProcedimento { get; set; }

        public string BoletimOcorrencia { get; set; }

        public string Artigo { get; set; }

        public string Indiciados { get; set; }

        public string UnidadePolicial { get; set; }

        public DateTime? DataFato { get; set; }

        public DateTime? Instauracao { get; set; }

        public string Situacao { get; set; }

        public string Observacao { get; set; }
    }
}
