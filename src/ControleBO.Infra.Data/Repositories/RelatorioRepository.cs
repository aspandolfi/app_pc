using System.Collections.Generic;
using System.Linq;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Queries;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleBO.Infra.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly SpcContext DbContext;

        public RelatorioRepository(SpcContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public IEnumerable<EstatisticaAssuntoQuery> GetEstatisticaAssunto()
        {
            var query = DbContext.Procedimentos.GroupBy(p => p.Assunto.Descricao)
                .Select(a => new EstatisticaAssuntoQuery
                {
                    Assunto = a.Key,
                    EmAndamento = a.Sum(x => x.HistoricoSituacoes.Count(p => p.SituacaoId == 1)),
                    NaJustica = a.Sum(x => x.HistoricoSituacoes.Count(p => p.SituacaoId == 2)),
                    Relatado = a.Sum(x => x.HistoricoSituacoes.Count(p => p.SituacaoId == 3))
                })
                .ToList();

            return query;
        }

        public IEnumerable<RelacaoProcedimentoQuery> GetRelacaoProcedimentos(int situacaoId)
        {
            var query = DbContext.Procedimentos
                                 .Where(x => x.SituacaoAtualId == situacaoId)
                                 .Select(p => new RelacaoProcedimentoQuery
                                 {
                                     Artigo = p.Artigo.Descricao,
                                     BoletimOcorrencia = p.BoletimOcorrencia,
                                     DataFato = p.DataFato,
                                     Instauracao = p.DataInstauracao,
                                     Indiciados = string.Join("<br/>", p.Autores.Select(a => a.Nome)),
                                     NumeroProcedimento = p.Id,
                                     Situacao = p.SituacaoAtual.Descricao,
                                     UnidadePolicial = p.DelegaciaOrigem.Descricao
                                 })
                                 .ToList();

            return query;
        }
    }
}
