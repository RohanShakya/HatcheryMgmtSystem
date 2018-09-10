namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "BatchCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batches", "BatchCount");
        }
    }
}
