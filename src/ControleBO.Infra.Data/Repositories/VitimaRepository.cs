﻿using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class VitimaRepository : Repository<Vitima>, IVitimaRepository
    {
        public VitimaRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            //bool exists = DbSet.Any(x => stringToSearch.Contains(x.Nome));

            string nome = stringToSearch[0];
            int procedimentoId = Convert.ToInt32(stringToSearch[1]);

            return DbSet.Any(x => EF.Functions.Like(nome, x.Nome) && x.ProcedimentoId == procedimentoId);
        }

        public IEnumerable<Vitima> GetVitimasByText(string text)
        {
            return DbSet.Where(x => EF.Functions.Like(text, x.Nome));
        }
    }
}
