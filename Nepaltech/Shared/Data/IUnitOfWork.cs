using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;


namespace Nepaltech.Shared.Data
{
    public interface IUnitOfWork : IDisposable 
    {
        IDataContext DataContext { get; set; }
        string GroupId { get; set; }
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepository<TEntity> RepositoryAsync<TEntity>() where TEntity : class ;
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class ;
        //IF 04/09/2014 Add IsolationLevel
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
      
    }
}