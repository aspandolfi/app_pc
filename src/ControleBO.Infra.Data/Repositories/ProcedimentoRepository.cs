using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            //return DbSet.Any(x => stringToSearch.Contains(x.BoletimUnificado));
            return DbSet.Any(x => EF.Functions.Like(stringToSearch[0], x.BoletimUnificado));
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
