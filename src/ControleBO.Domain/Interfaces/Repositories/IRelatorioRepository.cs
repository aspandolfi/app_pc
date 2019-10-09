using ControleBO.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IRelatorioRepository : IDisposable
    {
        IEnumerable<EstatisticaAssuntoQuery> GetEstatisticaAssunto(DateTime? de, DateTime? ate);
        IEnumerable<RelacaoProcedimentoQuery> GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate);
        IEnumerable<RelacaoIndiciadoQuery> GetRelacaoIndiciados();
        IEnumerable<RelacaoVitimaQuery> GetRelacaoVitimas();
    }
}
