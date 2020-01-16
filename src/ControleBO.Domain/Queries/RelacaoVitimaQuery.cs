namespace ControleBO.Domain.Queries
{
    public class RelacaoVitimaQuery
    {
        public string Vitima { get; set; }

        public int NumeroProcedimento { get; set; }

        public string Artigo { get; set; }

        public string TipoProcedimento { get; set; }

        public string SituacaoAtual { get; set; }

        public string SituacaoAtualCodigo { get; set; }

        public int SituacaoAtualId { get; set; }
    }
}
