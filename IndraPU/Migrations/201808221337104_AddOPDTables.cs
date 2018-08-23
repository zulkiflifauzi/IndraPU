namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOPDTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OPDId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OPD", t => t.OPDId, cascadeDelete: true)
                .Index(t => t.OPDId);
            
            CreateTable(
                "dbo.OPD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Structure = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "OPDId", "dbo.OPD");
            DropIndex("dbo.Activities", new[] { "OPDId" });
            DropTable("dbo.OPD");
            DropTable("dbo.Activities");
        }
    }
}
