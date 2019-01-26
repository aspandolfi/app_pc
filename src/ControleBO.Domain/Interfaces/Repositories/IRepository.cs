using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IRepository<TModel> : IDisposable where TModel : class
    {
        void Add(TModel obj);
        void AddRange(IEnumerable<TModel> objs);
        TModel GetById(int id);
        IQueryable<TModel> GetAll();
        void Update(TModel obj);
        void UpdateRange(IEnumerable<TModel> objs);
        void Remove(int id);
        void RemoveRange(IEnumerable<TModel> objs);
        int SaveChanges();

        IEnumerable<TModel> GetPaged(int page, int pageSize);

        IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                  Expression<Func<TModel, object>> orderBy = null);

        IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                               Expression<Func<TModel, object>> orderBy = null);
    }
}
