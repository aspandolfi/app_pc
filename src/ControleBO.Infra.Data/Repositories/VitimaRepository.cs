using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class VitimaRepository : Repository<Vitima>, IVitimaRepository
    {
        public VitimaRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override Vitima GetById(int id)
        {
            return GetAsNoTracking(x => x.Id == id, x => x.Naturalidade);
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            //bool exists = DbSet.Any(x => stringToSearch.Contains(x.Nome));

            string nome = paramsToSearch[0] as string;
            int? procedimentoId = paramsToSearch[1] as int?;

            return DbSet.Any(x => EF.Functions.Like(nome, x.Nome) && x.ProcedimentoId == procedimentoId);
        }

        public IEnumerable<Vitima> GetVitimasByText(string text)
        {
            return DbSet.Where(x => EF.Functions.Like(text, x.Nome));
        }
    }
}
