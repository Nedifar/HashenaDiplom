namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ni1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        idAd = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        date = c.DateTime(nullable: false),
                        idDepartament = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAd)
                .ForeignKey("dbo.Departaments", t => t.idDepartament, cascadeDelete: true)
                .Index(t => t.idDepartament);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "idDepartament", "dbo.Departaments");
            DropIndex("dbo.Ads", new[] { "idDepartament" });
            DropTable("dbo.Ads");
        }
    }
}
