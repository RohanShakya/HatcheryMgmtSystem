namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedTypeaddedonBreedEggProduction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedEggProductions", "BreedTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BreedEggProductions", "BreedTypeId");
            AddForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedEggProductions", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedEggProductions", new[] { "BreedTypeId" });
            DropColumn("dbo.BreedEggProductions", "BreedTypeId");
        }
    }
}
