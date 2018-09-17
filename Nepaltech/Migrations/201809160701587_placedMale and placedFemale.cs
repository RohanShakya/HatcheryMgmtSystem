namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placedMaleandplacedFemale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "PlacedMale", c => c.Int(nullable: false));
            AddColumn("dbo.Batches", "PlacedFemale", c => c.Int(nullable: false));
            DropColumn("dbo.Batches", "BatchCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batches", "BatchCount", c => c.Int(nullable: false));
            DropColumn("dbo.Batches", "PlacedFemale");
            DropColumn("dbo.Batches", "PlacedMale");
        }
    }
}
