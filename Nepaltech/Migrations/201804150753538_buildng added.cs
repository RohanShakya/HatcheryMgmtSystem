namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildngadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Buildings = c.String(),
                        HatcheryFarmId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HatcheryFarms", t => t.HatcheryFarmId)
                .Index(t => t.HatcheryFarmId);
            
            CreateTable(
                "dbo.BuildingsModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FarmName = c.String(),
                        FarmId = c.String(),
                        Building = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BatchChicken", "BuildingId", c => c.String(maxLength: 128));
            AddColumn("dbo.Locations", "BuildingId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BatchChicken", "BuildingId");
            CreateIndex("dbo.Locations", "BuildingId");
            AddForeignKey("dbo.BatchChicken", "BuildingId", "dbo.Buildings", "Id");
            AddForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.BatchChicken", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Buildings", "HatcheryFarmId", "dbo.HatcheryFarms");
            DropIndex("dbo.Locations", new[] { "BuildingId" });
            DropIndex("dbo.Buildings", new[] { "HatcheryFarmId" });
            DropIndex("dbo.BatchChicken", new[] { "BuildingId" });
            DropColumn("dbo.Locations", "BuildingId");
            DropColumn("dbo.BatchChicken", "BuildingId");
            DropTable("dbo.BuildingsModels");
            DropTable("dbo.Buildings");
        }
    }
}
