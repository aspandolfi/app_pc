using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class SituacaoProcedimentoRepository : Repository<SituacaoProcedimento>, ISituacaoProcedimentoRepository
    {
        public SituacaoProcedimentoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            int? procedimentoId = paramsToSearch[0] as int?;
            int? situacaoId = paramsToSearch[1] as int?;
            int? situacaoTipoId = paramsToSearch.Length > 1 ? paramsToSearch[2] as int? : null;


            if (situacaoTipoId.HasValue)
            {
                return DbSet.Any(x => x.ProcedimentoId == procedimentoId
                                   && x.SituacaoId == situacaoId
                                   && x.SituacaoTipoId == situacaoTipoId);
            }

            return DbSet.Any(x => x.ProcedimentoId == procedimentoId
                               && x.SituacaoId == situacaoId);
        }

        public SituacaoProcedimento GetCurrentByProcedimentoId(int procedimentoId)
        {
            return DbSet.LastOrDefault(x => x.ProcedimentoId == procedimentoId);
        }
    }
}
