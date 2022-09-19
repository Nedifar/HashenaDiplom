namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnergyEfficiencies",
                c => new
                    {
                        idEnergyEfficiency = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        EnergyEfficiency_idEnergyEfficiency = c.Int(),
                    })
                .PrimaryKey(t => t.idEnergyEfficiency)
                .ForeignKey("dbo.EnergyEfficiencies", t => t.EnergyEfficiency_idEnergyEfficiency)
                .Index(t => t.EnergyEfficiency_idEnergyEfficiency);
            
            AddColumn("dbo.Orders", "status", c => c.String());
            AddColumn("dbo.Orders", "fullPrice", c => c.String());
            AddColumn("dbo.Products", "idEnergyEfficiency", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "idEnergyEfficiency");
            AddForeignKey("dbo.Products", "idEnergyEfficiency", "dbo.EnergyEfficiencies", "idEnergyEfficiency", cascadeDelete: true);
            DropColumn("dbo.Products", "energyEfficiency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "energyEfficiency", c => c.String());
            DropForeignKey("dbo.Products", "idEnergyEfficiency", "dbo.EnergyEfficiencies");
            DropForeignKey("dbo.EnergyEfficiencies", "EnergyEfficiency_idEnergyEfficiency", "dbo.EnergyEfficiencies");
            DropIndex("dbo.EnergyEfficiencies", new[] { "EnergyEfficiency_idEnergyEfficiency" });
            DropIndex("dbo.Products", new[] { "idEnergyEfficiency" });
            DropColumn("dbo.Products", "idEnergyEfficiency");
            DropColumn("dbo.Orders", "fullPrice");
            DropColumn("dbo.Orders", "status");
            DropTable("dbo.EnergyEfficiencies");
        }
    }
}
