namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedTypesaddedinBreedMortality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedMortalities", "BreedTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BreedMortalities", "BreedTypeId");
            AddForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedMortalities", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedMortalities", new[] { "BreedTypeId" });
            DropColumn("dbo.BreedMortalities", "BreedTypeId");
        }
    }
}
