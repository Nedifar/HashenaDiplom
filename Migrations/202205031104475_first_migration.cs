namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        idAdministrator = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.idAdministrator);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        idBuyer = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        firstName = c.String(),
                        midlleName = c.String(),
                        phone = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.idBuyer);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        idOrder = c.Int(nullable: false, identity: true),
                        idEmployee = c.Int(),
                        idService = c.Int(nullable: false),
                        idBuyer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idOrder)
                .ForeignKey("dbo.Buyers", t => t.idBuyer, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.idService, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.idEmployee)
                .Index(t => t.idEmployee)
                .Index(t => t.idService)
                .Index(t => t.idBuyer);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        idEmployee = c.Int(nullable: false, identity: true),
                        operationCode = c.String(),
                        idDepartament = c.Int(nullable: false),
                        lastName = c.String(),
                        firstName = c.String(),
                        midlleName = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.idEmployee)
                .ForeignKey("dbo.Departaments", t => t.idDepartament, cascadeDelete: true)
                .Index(t => t.idDepartament);
            
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        idDepartament = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.idDepartament);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        idService = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        idDepartament = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idService)
                .ForeignKey("dbo.Departaments", t => t.idDepartament, cascadeDelete: true)
                .Index(t => t.idDepartament);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        idOrderProduct = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        idOrder = c.Int(nullable: false),
                        idProduct = c.Int(nullable: false),
                        Finished = c.DateTime(),
                        Accepted = c.DateTime(),
                        idEmployee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idOrderProduct)
                .ForeignKey("dbo.Employees", t => t.idEmployee, cascadeDelete: false)
                .ForeignKey("dbo.Orders", t => t.idOrder, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.idProduct, cascadeDelete: false)
                .Index(t => t.idOrder)
                .Index(t => t.idProduct)
                .Index(t => t.idEmployee);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        idProduct = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                        enginePower = c.String(),
                        voltage = c.Double(nullable: false),
                        frequince = c.Double(nullable: false),
                        technicalRequirements = c.String(),
                        energyEfficiency = c.String(),
                        cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idProduct);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id_History = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        dateSign = c.String(),
                        Attempt = c.String(),
                    })
                .PrimaryKey(t => t.Id_History);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "idEmployee", "dbo.Employees");
            DropForeignKey("dbo.OrderProducts", "idProduct", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "idOrder", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "idEmployee", "dbo.Employees");
            DropForeignKey("dbo.Orders", "idService", "dbo.Services");
            DropForeignKey("dbo.Services", "idDepartament", "dbo.Departaments");
            DropForeignKey("dbo.Employees", "idDepartament", "dbo.Departaments");
            DropForeignKey("dbo.Orders", "idBuyer", "dbo.Buyers");
            DropIndex("dbo.OrderProducts", new[] { "idEmployee" });
            DropIndex("dbo.OrderProducts", new[] { "idProduct" });
            DropIndex("dbo.OrderProducts", new[] { "idOrder" });
            DropIndex("dbo.Services", new[] { "idDepartament" });
            DropIndex("dbo.Employees", new[] { "idDepartament" });
            DropIndex("dbo.Orders", new[] { "idBuyer" });
            DropIndex("dbo.Orders", new[] { "idService" });
            DropIndex("dbo.Orders", new[] { "idEmployee" });
            DropTable("dbo.Histories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Services");
            DropTable("dbo.Departaments");
            DropTable("dbo.Employees");
            DropTable("dbo.Orders");
            DropTable("dbo.Buyers");
            DropTable("dbo.Administrators");
        }
    }
}
