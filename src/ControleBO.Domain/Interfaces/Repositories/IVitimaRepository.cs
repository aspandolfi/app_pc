using ControleBO.Domain.Models;
using System.Collections.Generic;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IVitimaRepository : IRepository<Vitima>
    {
        IEnumerable<Vitima> GetVitimasByText(string text);
    }
}
