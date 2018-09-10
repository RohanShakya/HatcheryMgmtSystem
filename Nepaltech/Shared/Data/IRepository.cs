using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Nepaltech.Entities;

namespace Nepaltech.Shared.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Add(TEntity entity);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        TEntity GetById(string id);
        IQueryable<TEntity> Query();
        TEntity Get(string id);
        IQueryable<TEntity> GetAll();
        IRepository<T> GetRepository<T>() where T : class;


        Task<bool> DeleteAsync(params object[] keyValues);

        IQueryable<TEntity> GetAllActive();
        void Create(TEntity entity);
        IQueryable<TEntity> List();
       
    }
}