namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchclosed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "Closed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batches", "Closed");
        }
    }
}
