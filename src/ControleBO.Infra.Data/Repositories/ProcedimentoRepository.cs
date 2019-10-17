using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Domain.Queries;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            return DbSet.Any(x => EF.Functions.Like(str, x.BoletimUnificado));
        }

        public IEnumerable<ProcedimentoListQuery> GetProcedimementoLists()
        {
            return DbContext.ProcedimentoLists.OrderByDescending(x => x.DataInsercao).ToList();
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
