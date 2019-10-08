using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleBO.Infra.Data.Context
{
    public class SpcContextInitializer
    {
        private readonly SpcContext _context;

        public SpcContextInitializer(SpcContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Database.GetPendingMigrations().Count() > 0)
            {
                _context.Database.Migrate();
            }

            if (_context.Municipios.Count() == 0)
            {
                _context.Seed();
            }
        }
    }
}
