namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeFromandAgeToaddedinBreedFeeds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedFeeds", "AgeFrom", c => c.Int(nullable: false));
            AddColumn("dbo.BreedFeeds", "AgeTo", c => c.Int(nullable: false));
            DropColumn("dbo.BreedFeeds", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BreedFeeds", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.BreedFeeds", "AgeTo");
            DropColumn("dbo.BreedFeeds", "AgeFrom");
        }
    }
}
