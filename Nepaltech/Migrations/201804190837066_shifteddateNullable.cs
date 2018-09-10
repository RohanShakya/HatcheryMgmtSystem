namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shifteddateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BatchChicken", "ShiftedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BatchChicken", "ShiftedDate", c => c.DateTime(nullable: false));
        }
    }
}
