using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nepaltech.Shared.Data
{
    public interface IDataContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        //DbSet<T> Set<T>() where T : class;
    }
}