using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string nome = paramsToSearch[0] as string;
            string uf = paramsToSearch[1] as string;
            return DbSet.Any(m => nome.Contains(m.Nome) && uf.Contains(m.UF));
        }
    }
}
