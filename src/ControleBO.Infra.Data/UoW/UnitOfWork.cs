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
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
