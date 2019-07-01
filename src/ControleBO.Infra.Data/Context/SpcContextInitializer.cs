using System;
using System.Collections.Generic;
using System.Text;

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
            if (_context.Database.EnsureCreated())
            {
                _context.Seed();
            }
        }
    }
}
