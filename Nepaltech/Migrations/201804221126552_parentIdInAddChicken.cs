namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentIdInAddChicken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BatchChicken", "ParentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BatchChicken", "ParentId");
        }
    }
}
