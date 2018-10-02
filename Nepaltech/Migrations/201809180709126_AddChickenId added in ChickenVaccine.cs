namespace Nepaltech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChickenIdaddedinChickenVaccine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChickenVaccines", "AddChickenId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChickenVaccines", "AddChickenId");
            AddForeignKey("dbo.ChickenVaccines", "AddChickenId", "dbo.BatchChicken", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChickenVaccines", "AddChickenId", "dbo.BatchChicken");
            DropIndex("dbo.ChickenVaccines", new[] { "AddChickenId" });
            DropColumn("dbo.ChickenVaccines", "AddChickenId");
        }
    }
}
