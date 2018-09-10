using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nepaltech.Entities;
using Nepaltech.Shared.Data;


namespace Nepaltech.Core.Hatchery
{
    public  class HatcheryDb : DbContext, IDataContext
    {
        public HatcheryDb() : base("hatchery")
        {

        }
        public DbSet<HatcheryFarm> HatcheryFarms { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<AddChickenInFarm> AddChickenInFarm { get; set; }


        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (DbEntityValidationResult failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (DbValidationError error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(),
                    ex
                    ).InnerException; // Add the original exception as the innerException
            }
        }
    }

    
}