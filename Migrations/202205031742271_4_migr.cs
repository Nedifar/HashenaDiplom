namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4_migr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency", "dbo.EnergyEfficiencies");
            DropIndex("dbo.EnergyEfficiencies", new[] { "EnergyEfficiency_idEnergyEfficiency" });
            DropColumn("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency", c => c.Int());
            CreateIndex("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency");
            AddForeignKey("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency", "dbo.EnergyEfficiencies", "idEnergyEfficiency");
        }
    }
}
