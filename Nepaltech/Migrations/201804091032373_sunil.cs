namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sunil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedEggProductions", "BreedTypeId", c => c.String(maxLength: 128));
            AddColumn("dbo.BreedMortalities", "BreedTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BreedEggProductions", "BreedTypeId");
            CreateIndex("dbo.BreedMortalities", "BreedTypeId");
            AddForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes", "Id");
            AddForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes");
            DropForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedMortalities", new[] { "BreedTypeId" });
            DropIndex("dbo.BreedEggProductions", new[] { "BreedTypeId" });
            DropColumn("dbo.BreedMortalities", "BreedTypeId");
            DropColumn("dbo.BreedEggProductions", "BreedTypeId");
        }
    }
}
