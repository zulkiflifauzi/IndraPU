namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOPDBudget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDBudget",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OPDId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OPD", t => t.OPDId, cascadeDelete: true)
                .Index(t => t.OPDId);
            
            DropColumn("dbo.OPD", "Budget");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPD", "Budget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.OPDBudget", "OPDId", "dbo.OPD");
            DropIndex("dbo.OPDBudget", new[] { "OPDId" });
            DropTable("dbo.OPDBudget");
        }
    }
}
