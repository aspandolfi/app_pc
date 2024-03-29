﻿using System;
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
        void Remove(Expression<Func<TModel, bool>> expression);
        int SaveChanges();

        bool Exists(params object[] paramsToSearch);

        bool Any(Expression<Func<TModel, bool>> predicate);

        TModel Get(Expression<Func<TModel, bool>> filter);

        TModel GetAsNoTracking(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TModel> GetPaged(Expression<Func<TModel, object>> orderBy, int page, int pageSize);

        IEnumerable<TModel> GetPaged(Expression<Func<TModel, bool>> filter, Expression<Func<TModel, object>> orderBy, int page, int pageSize);

        IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                  params Expression<Func<TModel, object>>[] includes);

        IQueryable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                  Expression<Func<TModel, object>> orderBy,
                                  params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TModel> GetAllAsNoTracking();

        IEnumerable<TModel> GetAllAsNoTracking(IEnumerable<Expression<Func<TModel, bool>>> filters,
                                               params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TModel> GetAllAsNoTracking(Expression<Func<TModel, bool>> filter,
                                               Expression<Func<TModel, object>> orderBy,
                                               params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TResult> GetAllAsNoTracking<TResult>(Expression<Func<TModel, TResult>> selector,
                                                         Expression<Func<TModel, bool>> filter,
                                                         Expression<Func<TModel, object>> orderBy,
                                                         params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TResult> GetAllAsNoTracking<TResult>(Expression<Func<TModel, TResult>> selector,
                                                         Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
                                                         params Expression<Func<TModel, object>>[] includes);

        IEnumerable<TModel> GetAllAsNoTracking(Expression<Func<TModel, bool>> filter,
                                               Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
                                               params Expression<Func<TModel, object>>[] includes);

        int Count();

        DateTime? LastUpdate();
    }
}
