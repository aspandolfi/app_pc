using ControleBO.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace ControleBO.Infra.Data.Context
{
    public partial class SpcContext : DbContext
    {
        public DbQuery<ProcedimentoListQuery> ProcedimentoLists { get; set; }
    }
}
