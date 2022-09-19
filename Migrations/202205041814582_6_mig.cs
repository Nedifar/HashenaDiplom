namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Qestions",
                c => new
                    {
                        idQestion = c.Int(nullable: false, identity: true),
                        idBuyer = c.Int(nullable: false),
                        message = c.String(),
                        request = c.String(),
                        closed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idQestion)
                .ForeignKey("dbo.Buyers", t => t.idBuyer, cascadeDelete: true)
                .Index(t => t.idBuyer);
            
            AddColumn("dbo.Buyers", "login", c => c.String());
            AddColumn("dbo.Buyers", "pas", c => c.String());
            AddColumn("dbo.Orders", "dateCreated", c => c.DateTime());
            AddColumn("dbo.Orders", "dateClosed", c => c.DateTime());
            AddColumn("dbo.Orders", "plan", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "fullPrice", c => c.Double(nullable: false));
            DropColumn("dbo.OrderProducts", "status");
            DropColumn("dbo.OrderProducts", "Finished");
            DropColumn("dbo.OrderProducts", "Accepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProducts", "Accepted", c => c.DateTime());
            AddColumn("dbo.OrderProducts", "Finished", c => c.DateTime());
            AddColumn("dbo.OrderProducts", "status", c => c.String());
            DropForeignKey("dbo.Qestions", "idBuyer", "dbo.Buyers");
            DropIndex("dbo.Qestions", new[] { "idBuyer" });
            AlterColumn("dbo.Orders", "fullPrice", c => c.String());
            DropColumn("dbo.Orders", "plan");
            DropColumn("dbo.Orders", "dateClosed");
            DropColumn("dbo.Orders", "dateCreated");
            DropColumn("dbo.Buyers", "pas");
            DropColumn("dbo.Buyers", "login");
            DropTable("dbo.Qestions");
        }
    }
}
