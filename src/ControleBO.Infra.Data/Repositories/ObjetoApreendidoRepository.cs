using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleBO.Infra.Data.Repositories
{
    public class ObjetoApreendidoRepository : Repository<ObjetoApreendido>, IObjetoApreendidoRepository
    {
        public ObjetoApreendidoRepository(SpcContext dbContext) : base(dbContext)
        {
        }

        public override bool Exists(params object[] paramsToSearch)
        {
            string descricao = paramsToSearch[0] as string;
            int? procedimentoId = paramsToSearch[1] as int?;

            return DbSet.Any(x => EF.Functions.Like(descricao, x.Descricao) && x.ProcedimentoId == procedimentoId);
        }
    }
}
