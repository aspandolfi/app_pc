using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            return DbSet.Any(m => stringToSearch.Contains(m.Nome) && stringToSearch.Contains(m.UF));
        }
    }
}
