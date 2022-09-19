namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "login", c => c.String());
            AddColumn("dbo.Employees", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "password");
            DropColumn("dbo.Employees", "login");
        }
    }
}
