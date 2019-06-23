using ControleBO.Domain.Models;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        Movimentacao GetLastByProcedimentoId(int procedimentoId);
    }
}
