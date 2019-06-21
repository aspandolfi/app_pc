using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ProcedimentoTipoRepository : Repository<ProcedimentoTipo>, IProcedimentoTipoRepository
    {
        public ProcedimentoTipoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string descricao = paramsToSearch[0] as string;
            string sigla = paramsToSearch[1] as string;
            return DbSet.Any(x => descricao.Contains(x.Descricao) || sigla.Contains(x.Sigla));
        }
    }
}
