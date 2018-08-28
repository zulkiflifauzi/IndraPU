namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentDept = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Method = c.String(nullable: false),
                        SourceOfFunds = c.String(nullable: false),
                        Budget = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Participants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programs", "StateId", "dbo.States");
            DropForeignKey("dbo.Programs", "CityId", "dbo.Cities");
            DropIndex("dbo.Programs", new[] { "CityId" });
            DropIndex("dbo.Programs", new[] { "StateId" });
            DropTable("dbo.Programs");
        }
    }
}
