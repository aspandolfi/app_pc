using ControleBO.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IRelatorioRepository : IDisposable
    {
        IEnumerable<EstatisticaAssuntoQuery> GetEstatisticaAssunto(DateTime? de = null, DateTime? ate = null);
        IEnumerable<RelacaoProcedimentoQuery> GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate);
        IEnumerable<RelacaoIndiciadoQuery> GetRelacaoIndiciados();
        IEnumerable<RelacaoVitimaQuery> GetRelacaoVitimas();
        IEnumerable<RelacaoProcedimentoSituacaoQuery> GetRelacaoProcedimentoPorSituacao();
    }
}
