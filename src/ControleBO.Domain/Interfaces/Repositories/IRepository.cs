using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface IRepository<TModel> : IDisposable where TModel : class
    {
        TModel Add(TModel obj);
        void AddRange(IEnumerable<TModel> objs);
        TModel GetById(int id);
        IQueryable<TModel> GetAll();
        TModel Update(TModel obj);
        void UpdateRange(IEnumerable<TModel> objs);
        void Remove(int id);
        void RemoveRange(IEnumerable<TModel> objs);
        int SaveChanges();

        bool Exists(params string[] stringToSearch);

        TModel Get(Expression<Func<TModel, bool>> filter);

        IEnumerable<TModel> GetPaged(Expression<Func<TModel, object>> orderBy, int page, int pageSize);

        IEnumerable<TModel> GetPaged(Expression<Func<TModel, bool>> filter, Expression<Func<TModel, object>> orderBy, int page, int pageSize);

        IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                  Expression<Func<TModel, object>> orderBy = null);

        IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters = null,
                                               Expression<Func<TModel, object>> orderBy = null);

        IEnumerable<TModel> GetAllAsNoTracking(Expression<Func<TModel, bool>> filter,
                                               Expression<Func<TModel, object>> orderBy = null);

        int Count();
    }
}
