using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            int? procedimentoId = paramsToSearch[1] as int?;

            return DbSet.Any(x => EF.Functions.Like(str, x.Destino) && x.ProcedimentoId == procedimentoId);
        }

        public Movimentacao GetLastByProcedimentoId(int procedimentoId)
        {
            return DbSet.Where(x => x.ProcedimentoId == procedimentoId)
                        .OrderBy(x => x.Data)
                        .LastOrDefault();
        }
    }
}
