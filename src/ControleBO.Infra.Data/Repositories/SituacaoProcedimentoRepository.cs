using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class SituacaoProcedimentoRepository : Repository<SituacaoProcedimento>, ISituacaoProcedimentoRepository
    {
        public SituacaoProcedimentoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params string[] stringToSearch)
        {
            int procedimentoId = Convert.ToInt32(stringToSearch[1]);
            int situacaoId = Convert.ToInt32(stringToSearch[2]);
            int? situacaoTipoId = stringToSearch.Length > 2 ? Convert.ToInt32(stringToSearch[3]) as int? : null;


            if (situacaoTipoId.HasValue)
            {
                return DbSet.Any(x => EF.Functions.Like(stringToSearch[0], x.Observacao)
                                     && x.ProcedimentoId == procedimentoId
                                     && x.SituacaoId == situacaoId
                                     && x.SituacaoTipoId == situacaoTipoId);
            }

            return DbSet.Any(x => EF.Functions.Like(stringToSearch[0], x.Observacao)
                                     && x.ProcedimentoId == procedimentoId
                                     && x.SituacaoId == situacaoId);
        }

        public SituacaoProcedimento GetCurrentByProcedimentoId(int procedimentoId)
        {
            return DbSet.LastOrDefault(x => x.ProcedimentoId == procedimentoId);
        }
    }
}
