namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breedTypeaddedinBreedWeight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes");
            DropForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedEggProductions", new[] { "BreedTypeId" });
            DropIndex("dbo.BreedMortalities", new[] { "BreedTypeId" });
            AddColumn("dbo.BreedWeights", "BreedTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BreedWeights", "BreedTypeId");
            AddForeignKey("dbo.BreedWeights", "BreedTypeId", "dbo.BreedTypes", "Id");
            DropColumn("dbo.BreedEggProductions", "BreedTypeId");
            DropColumn("dbo.BreedMortalities", "BreedTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BreedMortalities", "BreedTypeId", c => c.String(maxLength: 128));
            AddColumn("dbo.BreedEggProductions", "BreedTypeId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.BreedWeights", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedWeights", new[] { "BreedTypeId" });
            DropColumn("dbo.BreedWeights", "BreedTypeId");
            CreateIndex("dbo.BreedMortalities", "BreedTypeId");
            CreateIndex("dbo.BreedEggProductions", "BreedTypeId");
            AddForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes", "Id");
            AddForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes", "Id");
        }
    }
}
