﻿using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class SituacaoTipoRepository : Repository<SituacaoTipo>, ISituacaoTipoRepository
    {
        public SituacaoTipoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            return DbSet.Any(x => EF.Functions.Like(stringToSearch[0], x.Descricao));
        }
    }
}
