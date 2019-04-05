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

        public override bool Exists(params string[] stringToSearch)
        {
            return DbSet.Any(x => stringToSearch.Contains(x.Descricao) || stringToSearch.Contains(x.Sigla));
        }
    }
}
