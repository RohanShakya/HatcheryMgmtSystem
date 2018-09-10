namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedtypeaddedinBreedFeeds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedFeeds", "BreedTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BreedFeeds", "BreedTypeId");
            AddForeignKey("dbo.BreedFeeds", "BreedTypeId", "dbo.BreedTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedFeeds", "BreedTypeId", "dbo.BreedTypes");
            DropIndex("dbo.BreedFeeds", new[] { "BreedTypeId" });
            DropColumn("dbo.BreedFeeds", "BreedTypeId");
        }
    }
}
