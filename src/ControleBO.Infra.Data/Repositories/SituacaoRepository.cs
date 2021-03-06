﻿using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class SituacaoRepository : Repository<Situacao>, ISituacaoRepository
    {
        public SituacaoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string str = paramsToSearch[0] as string;
            return DbSet.Any(x => EF.Functions.Like(str, x.Descricao));
        }
    }
}
