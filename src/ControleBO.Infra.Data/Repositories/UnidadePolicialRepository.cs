using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class UnidadePolicialRepository : Repository<UnidadePolicial>, IUnidadePolicialRepository
    {
        public UnidadePolicialRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            return DbContext.UnidadesPolicia.Any(x => str.Contains(x.Descricao));
        }
    }
}
