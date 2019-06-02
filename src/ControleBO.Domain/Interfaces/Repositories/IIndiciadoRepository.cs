using ControleBO.Domain.Models;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IIndiciadoRepository : IRepository<Indiciado>
    {
        IEnumerable<Indiciado> GetIndiciadosByText(string text);
    }
}
