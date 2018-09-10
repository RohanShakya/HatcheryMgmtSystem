#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Nepaltech.Entities;
using Nepaltech.Shared.Data;

#endregion

namespace Nepaltech.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Private Fields

        private readonly IDataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;
        public HatcheryDb DbContext { get; set; }

        #endregion Private Fields

        public Repository(IDataContext unitofwork)
        {
            _context = unitofwork;

            DbContext = _context as HatcheryDb;
            // Temporarily for FakeDbContext, Unit Test and Fakes
            var dbContext = _context as HatcheryDb;
                        if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
            }
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }




        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void Add(TEntity entity)
        {

            this._dbSet.Add(entity);

        }
        public void Create(TEntity entity)
        {
           // TrySetProperty(entity, "DateCreated", DateTime.Now);
            TrySetProperty(entity, "DateUpdated", DateTime.Now);
            this._dbSet.Add(entity);
        }
        public void Insert(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            TrySetProperty(entity, "DateUpdated", DateTime.Now);
            _dbSet.AddOrUpdate(entity);

        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            TrySetProperty(entity, "DateDeleted", DateTime.Now);
            _dbSet.AddOrUpdate(entity);

        }

        public TEntity GetById(string id)
        {
            return this._dbSet.Find(id);
        }

        public IQueryable<TEntity> Query()
        {
            return this._dbSet;
            // return new QueryFluent<TEntity>(this);
        }




        public IQueryable<TEntity> GetAllActive()
        {
            return _dbSet;
            //.Where(x=>x.DateDeleted==null);
        }

        public TEntity Get(string value)
        {
            var type = typeof(TEntity).GetProperty("Id").PropertyType;
            if (type == typeof(int))
            {
                return GetByInt(Convert.ToInt32(value));
            }
            else
            {
                return GetById(value);
            }

            //var foo=new Foo();
            //foo.Value = value;
            //int id = foo.CastValue<int>();
            //return GetByInt(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._dbSet;
        }
        public IQueryable<TEntity> List()
        {
            return this._dbSet;
        }

        //IRepository<T> IRepository<TEntity>.GetRepository<T>()
        //{
        //   throw  new NotImplementedException();
        //}

        public IRepository<T> GetRepository<T>() where T : class
        {
            return _unitOfWork.Repository<T>();
        }



        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }



        internal IQueryable<TEntity> Select(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                // query = query.AsExpandable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }

        // Add or Updating an object graph
        [Obsolete("Will be renamed to UpsertGraph(TEntity entity) in next version.")]
        public virtual void InsertOrUpdateGraph(TEntity entity)
        {

            _entitesChecked = null;
            _dbSet.Attach(entity);
        }

        // tracking of all processed entities in the object graph when calling SyncObjectGraph
        HashSet<object> _entitesChecked;
        private TEntity GetByInt(int id)
        {
            return _dbSet.Find(id);

        }
        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }
    }
   public class Foo
    {
        public string Value { get; set; }
        public Type TheType { get; set; }

        public T CastValue<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }
    }
}