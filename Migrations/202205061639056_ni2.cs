namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ni2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "idEmployee", "dbo.Employees");
            DropIndex("dbo.OrderProducts", new[] { "idEmployee" });
            RenameColumn(table: "dbo.OrderProducts", name: "idEmployee", newName: "Employee_idEmployee");
            AlterColumn("dbo.OrderProducts", "Employee_idEmployee", c => c.Int());
            CreateIndex("dbo.OrderProducts", "Employee_idEmployee");
            AddForeignKey("dbo.OrderProducts", "Employee_idEmployee", "dbo.Employees", "idEmployee");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "Employee_idEmployee", "dbo.Employees");
            DropIndex("dbo.OrderProducts", new[] { "Employee_idEmployee" });
            AlterColumn("dbo.OrderProducts", "Employee_idEmployee", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.OrderProducts", name: "Employee_idEmployee", newName: "idEmployee");
            CreateIndex("dbo.OrderProducts", "idEmployee");
            AddForeignKey("dbo.OrderProducts", "idEmployee", "dbo.Employees", "idEmployee", cascadeDelete: true);
        }
    }
}
