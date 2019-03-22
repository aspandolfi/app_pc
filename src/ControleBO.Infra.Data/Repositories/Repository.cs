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
        protected DbSet<TModel> DbSet;

        public TModel Add(TModel obj)
        {
            return DbSet.Add(obj).Entity;
        }

        public IQueryable<TModel> GetAll()
        {
            return DbSet;
        }

        public IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                         Expression<Func<TModel, object>> orderBy = null)
        {
            IQueryable<TModel> query = DbSet;

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
            return DbSet.Find(id);
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public TModel Update(TModel obj)
        {
            return DbSet.Update(obj).Entity;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public Repository(SpcContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TModel>();
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
                DbSet = null;

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
            DbSet.AddRange(objs);
        }

        public void UpdateRange(IEnumerable<TModel> objs)
        {
            DbSet.UpdateRange(objs);
        }

        public void RemoveRange(IEnumerable<TModel> objs)
        {
            DbSet.RemoveRange(objs);
        }

        public IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters = null,
                                                      Expression<Func<TModel, object>> orderBy = null)
        {
            IQueryable<TModel> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            if (orderBy != null)
            {
                return query.OrderBy(orderBy).AsNoTracking();
            }

            return query.AsNoTracking();
        }

        public IEnumerable<TModel> GetPaged(int page, int pageSize = 10)
        {
            IQueryable<TModel> query = DbSet;

            var skip = (page - 1) * pageSize;
            return query.Skip(skip).Take(pageSize).AsNoTracking().AsEnumerable();
        }

        public virtual bool Exists(string stringToSearch)
        {
            throw new NotImplementedException("Método não implementado na classe filha.");
        }
    }
}
