using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nepaltech.Entities;
using Nepaltech.Shared.Data;

namespace Nepaltech.Data
{
    public  class HatcheryDb : DbContext, IDataContext
    {
        public HatcheryDb() : base("hatchery")
        {

        }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<HatcheryFarm> HatcheryFarms { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<BreedTypes> BreedTypes { get; set; }
        public DbSet<Feeds> Feeds { get; set; }
        public DbSet<BreedFeeds> BreedFeeds { get; set; }
        public DbSet<BreedVaccine> BreedVaccines { get; set; }
        public DbSet<BreedWeight> BreedWeights { get; set; }
        public DbSet<BreedEggProductions> BreedEggProductions { get; set; }
        public DbSet<BreedMortality> BreedMortalities { get; set; }
        public DbSet<ChickenEggProduction> ChickenEggProductions { get; set; }
        public DbSet<ChickenFeeds> ChickenFeeds { get; set; }
        public DbSet<ChickenMortality> ChickenMortalities { get; set; }
        public DbSet<ChickenVaccine> ChickenVaccines{ get; set; }
        public DbSet<ChickenWeight> ChickenWeights{ get; set; }
        public DbSet<AddChickenInFarm> AddChickenInFarm { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<Building> Building { get; set; }
     //   public DbSet<BatchShifting> BatchShifting { get; set; }


        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<int> SaveChangesAsync()
        //{
        //    throw new System.NotImplementedException();
        //}

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

        public System.Data.Entity.DbSet<Nepaltech.Models.Forms.ChickenMortalityModel> ChickenMortalityModels { get; set; }

        public System.Data.Entity.DbSet<Nepaltech.Models.Forms.BuildingsModel> BuildingsModels { get; set; }
    }

    
}