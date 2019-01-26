using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Infra.Data.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected SpcContext DbContext;
        private DbSet<TModel> _dbSet;

        public void Add(TModel obj)
        {
            _dbSet.Add(obj);
        }

        public IQueryable<TModel> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                         Expression<Func<TModel, object>> orderBy = null)
        {
            IQueryable<TModel> query = _dbSet;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return query.OrderBy(orderBy);
            }

            return query;
        }

        public TModel GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public void Update(TModel obj)
        {
            _dbSet.Update(obj);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public Repository(SpcContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TModel>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    DbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                DbContext = null;
                _dbSet = null;

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public void AddRange(IEnumerable<TModel> objs)
        {
            _dbSet.AddRange(objs);
        }

        public void UpdateRange(IEnumerable<TModel> objs)
        {
            _dbSet.UpdateRange(objs);
        }

        public void RemoveRange(IEnumerable<TModel> objs)
        {
            _dbSet.RemoveRange(objs);
        }

        public IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                                      Expression<Func<TModel, object>> orderBy = null)
        {
            IQueryable<TModel> query = _dbSet;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return query.OrderBy(orderBy).AsNoTracking();
            }

            return query.AsNoTracking();
        }

        public IEnumerable<TModel> GetPaged(int page, int pageSize = 10)
        {
            IQueryable<TModel> query = _dbSet;

            var skip = (page - 1) * pageSize;
            return query.Skip(skip).Take(pageSize).AsNoTracking().AsEnumerable();
        }
    }
}
