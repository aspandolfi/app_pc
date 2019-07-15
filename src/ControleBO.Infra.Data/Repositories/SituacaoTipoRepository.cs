using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class SituacaoTipoRepository : Repository<SituacaoTipo>, ISituacaoTipoRepository
    {
        public SituacaoTipoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            int? situacaoId = paramsToSearch[1] as int?;

            return DbSet.Any(x => EF.Functions.Like(str, x.Descricao) && x.SituacaoId == situacaoId);
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

        public DateTime? LastUpdate(int situacaoId)
        {
            DateTime? maxDate = null;

            if (DbSet.Any(x => x.SituacaoId == situacaoId))
            {
                maxDate = DbSet.Where(x => x.SituacaoId == situacaoId).Max(x => x.ModificadoEm);
            }

            return maxDate;
        }
    }
}
