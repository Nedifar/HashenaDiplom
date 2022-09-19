namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ni3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "dateRegistr", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyers", "dateRegistr");
        }
    }
}
