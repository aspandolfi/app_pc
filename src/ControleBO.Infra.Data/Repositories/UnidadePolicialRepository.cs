using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class UnidadePolicialRepository : Repository<UnidadePolicial>, IUnidadePolicialRepository
    {
        public UnidadePolicialRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            return DbContext.UnidadesPolicia.Any(x => stringToSearch.Contains(x.Descricao));
        }
    }
}
