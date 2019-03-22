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

        public override bool Exists(string stringToSearch)
        {
            return DbSet.Any(x => x.Descricao == stringToSearch || x.Sigla == stringToSearch);
        }
    }
}
