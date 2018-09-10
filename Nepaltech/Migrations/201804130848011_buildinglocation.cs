namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildinglocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "BuildingId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Locations", "BuildingId");
            AddForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Locations", new[] { "BuildingId" });
            DropColumn("dbo.Locations", "BuildingId");
        }
    }
}
