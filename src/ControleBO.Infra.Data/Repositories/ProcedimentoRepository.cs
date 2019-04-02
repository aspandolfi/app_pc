using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(string stringToSearch)
        {
            return DbSet.Any(x => stringToSearch.Contains(x.BoletimUnificado));
        }
    }
}
