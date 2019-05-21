using ControleBO.Domain.Interfaces;
using ControleBO.Infra.Data.Context;

namespace ControleBO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SpcContext _context;

        public UnitOfWork(SpcContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
