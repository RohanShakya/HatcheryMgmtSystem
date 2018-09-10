namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildingaddedinaddchicken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BatchChicken", "BuildingId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BatchChicken", "BuildingId");
            AddForeignKey("dbo.BatchChicken", "BuildingId", "dbo.Buildings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BatchChicken", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.BatchChicken", new[] { "BuildingId" });
            DropColumn("dbo.BatchChicken", "BuildingId");
        }
    }
}
