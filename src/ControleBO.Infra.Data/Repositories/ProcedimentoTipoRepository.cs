using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using System;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ProcedimentoTipoRepository : Repository<ProcedimentoTipo>, IProcedimentoTipoRepository
    {
        public ProcedimentoTipoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string descricao = paramsToSearch[0] as string;
            string sigla = paramsToSearch[1] as string;
            return DbSet.Any(x => descricao.Contains(x.Descricao) || sigla.Contains(x.Sigla));
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
