namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaCode = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Latitude = c.Long(),
                        Longitude = c.Long(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaCode = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Latitude = c.Long(),
                        Longitude = c.Long(),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "State_Id", "dbo.States");
            DropIndex("dbo.States", new[] { "State_Id" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
