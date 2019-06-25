using ControleBO.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IRelatorioRepository : IDisposable
    {
        IEnumerable<EstatisticaAssuntoQuery> GetEstatisticaAssunto();
    }
}
