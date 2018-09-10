namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialHatchery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BatchChicken",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(maxLength: 128),
                        FarmId = c.String(maxLength: 128),
                        LocationId = c.String(maxLength: 128),
                        TotalMale = c.Int(nullable: false),
                        TotalFemale = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.HatcheryFarms", t => t.FarmId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.BatchId)
                .Index(t => t.FarmId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        CountryId = c.String(maxLength: 128),
                        ArrivalDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        BreedId = c.String(maxLength: 128),
                        BreedTypeId = c.String(maxLength: 128),
                        TotalMale = c.Int(nullable: false),
                        TotalFemale = c.Int(nullable: false),
                        DeadMale = c.Int(nullable: false),
                        DeadFemale = c.Int(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.BreedTypes", t => t.BreedTypeId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.BreedId)
                .Index(t => t.BreedTypeId);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BreedTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        BreedType = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CountryName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HatcheryFarms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HatcheryFarmId = c.String(maxLength: 128),
                        Location = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HatcheryFarms", t => t.HatcheryFarmId)
                .Index(t => t.HatcheryFarmId);
            
            CreateTable(
                "dbo.BreedEggProductions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        TotalEggs = c.Int(nullable: false),
                        AgeinWeeks = c.Int(nullable: false),
                        HatchingEggs = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.BreedFeeds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        FeedId = c.String(maxLength: 128),
                        FeedName = c.String(),
                        GenderId = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        MaleQuantity = c.Single(nullable: false),
                        FemaleQuantity = c.Single(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.Feeds", t => t.FeedId)
                .Index(t => t.BreedId)
                .Index(t => t.FeedId);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeedName = c.String(),
                        Price = c.Single(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BreedMortalities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        MortalityPercentage = c.Int(nullable: false),
                        AgeinWeeks = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.BreedVaccines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        VaccineId = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.Vaccines", t => t.VaccineId)
                .Index(t => t.BreedId)
                .Index(t => t.VaccineId);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VaccineName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BreedWeights",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.ChickenEggProductions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(maxLength: 128),
                        LocationId = c.String(maxLength: 128),
                        TotalEggs = c.Int(nullable: false),
                        GoodEggs = c.Int(nullable: false),
                        SpoiltEggs = c.Int(nullable: false),
                        DateEntry = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        BatchChicken_Id = c.String(maxLength: 128),
                        BreedMortality_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.BatchChicken", t => t.BatchChicken_Id)
                .ForeignKey("dbo.BreedMortalities", t => t.BreedMortality_Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.BatchId)
                .Index(t => t.LocationId)
                .Index(t => t.BatchChicken_Id)
                .Index(t => t.BreedMortality_Id);
            
            CreateTable(
                "dbo.ChickenFeeds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(maxLength: 128),
                        LocationId = c.String(maxLength: 128),
                        FeedId = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        MaleQuantity = c.Single(nullable: false),
                        FemaleQuantity = c.Single(nullable: false),
                        DateEntry = c.DateTime(nullable: false),
                        RecommendedDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        BreedFeeds_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.BreedFeeds", t => t.BreedFeeds_Id)
                .ForeignKey("dbo.Feeds", t => t.FeedId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.BatchId)
                .Index(t => t.LocationId)
                .Index(t => t.FeedId)
                .Index(t => t.BreedFeeds_Id);
            
            CreateTable(
                "dbo.ChickenMortalities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(maxLength: 128),
                        LocationId = c.String(maxLength: 128),
                        DateEntry = c.DateTime(nullable: false),
                        MortalityPercentage = c.Int(nullable: false),
                        DeadChickenMale = c.Int(nullable: false),
                        DeadChickenFemale = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        BatchChicken_Id = c.String(maxLength: 128),
                        BreedMortality_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.BatchChicken", t => t.BatchChicken_Id)
                .ForeignKey("dbo.BreedMortalities", t => t.BreedMortality_Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.BatchId)
                .Index(t => t.LocationId)
                .Index(t => t.BatchChicken_Id)
                .Index(t => t.BreedMortality_Id);
            
            CreateTable(
                "dbo.ChickenMortalityModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(),
                        BatchCode = c.String(),
                        MortalityPercentage = c.Int(nullable: false),
                        BatchChickenId = c.String(),
                        DateEntry = c.DateTime(nullable: false),
                        DeadChickenMale = c.Int(nullable: false),
                        DeadChickenFemale = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        FarmName = c.String(),
                        Location = c.String(),
                        LocationId = c.String(),
                        Breed = c.String(),
                        BreedId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChickenVaccines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchId = c.String(maxLength: 128),
                        LocationId = c.String(maxLength: 128),
                        VaccineId = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        VaccinationDate = c.DateTime(nullable: false),
                        RecommendedDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        BreedVaccine_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.BreedVaccines", t => t.BreedVaccine_Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Vaccines", t => t.VaccineId)
                .Index(t => t.BatchId)
                .Index(t => t.LocationId)
                .Index(t => t.VaccineId)
                .Index(t => t.BreedVaccine_Id);
            
            CreateTable(
                "dbo.ChickenWeights",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BatchChickenId = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        DateEntry = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        BreedWeight_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BatchChicken", t => t.BatchChickenId)
                .ForeignKey("dbo.BreedWeights", t => t.BreedWeight_Id)
                .Index(t => t.BatchChickenId)
                .Index(t => t.BreedWeight_Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MedicineName = c.String(),
                        DiseaseName = c.String(),
                        RecomendedDoctor = c.String(),
                        BreedId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .Index(t => t.BreedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.ChickenWeights", "BreedWeight_Id", "dbo.BreedWeights");
            DropForeignKey("dbo.ChickenWeights", "BatchChickenId", "dbo.BatchChicken");
            DropForeignKey("dbo.ChickenVaccines", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.ChickenVaccines", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ChickenVaccines", "BreedVaccine_Id", "dbo.BreedVaccines");
            DropForeignKey("dbo.ChickenVaccines", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ChickenMortalities", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ChickenMortalities", "BreedMortality_Id", "dbo.BreedMortalities");
            DropForeignKey("dbo.ChickenMortalities", "BatchChicken_Id", "dbo.BatchChicken");
            DropForeignKey("dbo.ChickenMortalities", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ChickenFeeds", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ChickenFeeds", "FeedId", "dbo.Feeds");
            DropForeignKey("dbo.ChickenFeeds", "BreedFeeds_Id", "dbo.BreedFeeds");
            DropForeignKey("dbo.ChickenFeeds", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ChickenEggProductions", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ChickenEggProductions", "BreedMortality_Id", "dbo.BreedMortalities");
            DropForeignKey("dbo.ChickenEggProductions", "BatchChicken_Id", "dbo.BatchChicken");
            DropForeignKey("dbo.ChickenEggProductions", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.BreedWeights", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.BreedVaccines", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.BreedVaccines", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.BreedMortalities", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.BreedFeeds", "FeedId", "dbo.Feeds");
            DropForeignKey("dbo.BreedFeeds", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.BreedEggProductions", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.BatchChicken", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "HatcheryFarmId", "dbo.HatcheryFarms");
            DropForeignKey("dbo.BatchChicken", "FarmId", "dbo.HatcheryFarms");
            DropForeignKey("dbo.BatchChicken", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Batches", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Batches", "BreedTypeId", "dbo.BreedTypes");
            DropForeignKey("dbo.BreedTypes", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Batches", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Medicines", new[] { "BreedId" });
            DropIndex("dbo.ChickenWeights", new[] { "BreedWeight_Id" });
            DropIndex("dbo.ChickenWeights", new[] { "BatchChickenId" });
            DropIndex("dbo.ChickenVaccines", new[] { "BreedVaccine_Id" });
            DropIndex("dbo.ChickenVaccines", new[] { "VaccineId" });
            DropIndex("dbo.ChickenVaccines", new[] { "LocationId" });
            DropIndex("dbo.ChickenVaccines", new[] { "BatchId" });
            DropIndex("dbo.ChickenMortalities", new[] { "BreedMortality_Id" });
            DropIndex("dbo.ChickenMortalities", new[] { "BatchChicken_Id" });
            DropIndex("dbo.ChickenMortalities", new[] { "LocationId" });
            DropIndex("dbo.ChickenMortalities", new[] { "BatchId" });
            DropIndex("dbo.ChickenFeeds", new[] { "BreedFeeds_Id" });
            DropIndex("dbo.ChickenFeeds", new[] { "FeedId" });
            DropIndex("dbo.ChickenFeeds", new[] { "LocationId" });
            DropIndex("dbo.ChickenFeeds", new[] { "BatchId" });
            DropIndex("dbo.ChickenEggProductions", new[] { "BreedMortality_Id" });
            DropIndex("dbo.ChickenEggProductions", new[] { "BatchChicken_Id" });
            DropIndex("dbo.ChickenEggProductions", new[] { "LocationId" });
            DropIndex("dbo.ChickenEggProductions", new[] { "BatchId" });
            DropIndex("dbo.BreedWeights", new[] { "BreedId" });
            DropIndex("dbo.BreedVaccines", new[] { "VaccineId" });
            DropIndex("dbo.BreedVaccines", new[] { "BreedId" });
            DropIndex("dbo.BreedMortalities", new[] { "BreedId" });
            DropIndex("dbo.BreedFeeds", new[] { "FeedId" });
            DropIndex("dbo.BreedFeeds", new[] { "BreedId" });
            DropIndex("dbo.BreedEggProductions", new[] { "BreedId" });
            DropIndex("dbo.Locations", new[] { "HatcheryFarmId" });
            DropIndex("dbo.BreedTypes", new[] { "BreedId" });
            DropIndex("dbo.Batches", new[] { "BreedTypeId" });
            DropIndex("dbo.Batches", new[] { "BreedId" });
            DropIndex("dbo.Batches", new[] { "CountryId" });
            DropIndex("dbo.BatchChicken", new[] { "LocationId" });
            DropIndex("dbo.BatchChicken", new[] { "FarmId" });
            DropIndex("dbo.BatchChicken", new[] { "BatchId" });
            DropTable("dbo.Medicines");
            DropTable("dbo.ChickenWeights");
            DropTable("dbo.ChickenVaccines");
            DropTable("dbo.ChickenMortalityModels");
            DropTable("dbo.ChickenMortalities");
            DropTable("dbo.ChickenFeeds");
            DropTable("dbo.ChickenEggProductions");
            DropTable("dbo.BreedWeights");
            DropTable("dbo.Vaccines");
            DropTable("dbo.BreedVaccines");
            DropTable("dbo.BreedMortalities");
            DropTable("dbo.Feeds");
            DropTable("dbo.BreedFeeds");
            DropTable("dbo.BreedEggProductions");
            DropTable("dbo.Locations");
            DropTable("dbo.HatcheryFarms");
            DropTable("dbo.Countries");
            DropTable("dbo.BreedTypes");
            DropTable("dbo.Breeds");
            DropTable("dbo.Batches");
            DropTable("dbo.BatchChicken");
        }
    }
}
