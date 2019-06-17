using ControleBO.Domain.Models;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface ISituacaoProcedimentoRepository : IRepository<SituacaoProcedimento>
    {
        SituacaoProcedimento GetCurrentByProcedimentoId(int procedimentoId);
    }
}
