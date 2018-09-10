namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedbuilding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Locations", new[] { "BuildingId" });
            DropColumn("dbo.Locations", "BuildingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "BuildingId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Locations", "BuildingId");
            AddForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings", "Id");
        }
    }
}
