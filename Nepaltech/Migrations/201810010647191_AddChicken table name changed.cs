namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChickentablenamechanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BatchChicken", newName: "AddChicken");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AddChicken", newName: "BatchChicken");
        }
    }
}
