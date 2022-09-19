namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qestions", "main", c => c.String());
            AddColumn("dbo.Qestions", "status", c => c.String());
            DropColumn("dbo.Qestions", "closed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Qestions", "closed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Qestions", "status");
            DropColumn("dbo.Qestions", "main");
        }
    }
}
