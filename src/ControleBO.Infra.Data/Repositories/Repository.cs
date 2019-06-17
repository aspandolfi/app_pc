using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Infra.Data.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
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
                                         params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            query = query.IncludeMultiple(includes);

            return query;
        }

        public IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                         Expression<Func<TModel, object>> orderBy,
                                         params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            query = query.IncludeMultiple(includes);

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

        public virtual IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                                             params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            query = query.IncludeMultiple(includes);

            return query.AsNoTracking();
        }

        public IEnumerable<TModel> GetPaged(Expression<Func<TModel, object>> orderBy, int page, int pageSize = 10)
        {
            IQueryable<TModel> query = DbSet;

            //var skip = (page - 1) * pageSize;
            var skip = (page) * pageSize;
            return query.OrderBy(orderBy).Skip(skip).Take(pageSize).AsNoTracking().AsEnumerable();
        }

        public abstract bool Exists(params string[] stringToSearch);

        public TModel Get(Expression<Func<TModel, bool>> filter)
        {
            return DbSet.SingleOrDefault(filter);
        }

        public virtual IEnumerable<TModel> GetAllAsNoTracking(Expression<Func<TModel, bool>> filter,
                                                      Expression<Func<TModel, object>> orderBy,
                                                      params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.IncludeMultiple(includes);

            if (orderBy != null)
            {
                return query.OrderBy(orderBy).AsNoTracking();
            }

            return query.AsNoTracking();
        }

        public IEnumerable<TModel> GetPaged(Expression<Func<TModel, bool>> filter, Expression<Func<TModel, object>> orderBy, int page = 1, int pageSize = 10)
        {
            IQueryable<TModel> query = DbSet;

            //var skip = (page - 1) * pageSize;
            var skip = (page) * pageSize;
            return query.Where(filter).OrderBy(orderBy).Skip(skip).Take(pageSize).AsNoTracking().AsEnumerable();
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public virtual DateTime? LastUpdate()
        {
            throw new NotImplementedException("Não implementado na classe filha. LastUpdate");
        }

        public virtual IEnumerable<TResult> GetAllAsNoTracking<TResult>(Expression<Func<TModel, TResult>> selector,
                                                                Expression<Func<TModel, bool>> filter,
                                                                Expression<Func<TModel, object>> orderBy,
                                                                params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.IncludeMultiple(includes);

            if (orderBy != null)
            {
                return query.OrderBy(orderBy).AsNoTracking().Select(selector);
            }

            return query.AsNoTracking().Select(selector);
        }

        public IEnumerable<TModel> GetAllAsNoTracking(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbSet;

            query = query.IncludeMultiple(includes);

            return query;
        }
    }
}
