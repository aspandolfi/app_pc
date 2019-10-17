using ControleBO.Domain.Models;
using ControleBO.Domain.Queries;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IProcedimentoRepository : IRepository<Procedimento>
    {
        IEnumerable<ProcedimentoListQuery> GetProcedimementoLists();
    }
}
