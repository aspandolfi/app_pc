﻿using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class IndiciadoRepository : Repository<Indiciado>, IIndiciadoRepository
    {
        public IndiciadoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override Indiciado GetById(int id)
        {
            return GetAsNoTracking(x => x.Id == id, x => x.Naturalidade);
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string nome = paramsToSearch[0] as string;
            int? procedimentoId = paramsToSearch[1] as int?;

            return DbSet.Any(x => EF.Functions.Like(nome, x.Nome) && x.ProcedimentoId == procedimentoId);
        }

        public IEnumerable<Indiciado> GetIndiciadosByText(string text)
        {
            return DbSet.Where(x => EF.Functions.Like(text, x.Nome));
        }
    }
}
