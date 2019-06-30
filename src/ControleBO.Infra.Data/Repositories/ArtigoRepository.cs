using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ArtigoRepository : Repository<Artigo>, IArtigoRepository
    {
        public ArtigoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            return DbSet.Any(x => str.Contains(x.Descricao));
        }

        public override DateTime? LastUpdate()
        {
            DateTime? maxDate = null;

            if (Count() > 0)
            {
                maxDate = DbSet.Max(x => x.ModificadoEm);
            }

            return maxDate;
        }
    }
}
