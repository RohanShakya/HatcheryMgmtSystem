namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shifteddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BatchChicken", "ShiftedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BatchChicken", "ShiftedDate");
        }
    }
}
