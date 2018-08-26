namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterStateNavigationKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "State_Id", "dbo.States");
            DropIndex("dbo.States", new[] { "State_Id" });
            DropColumn("dbo.States", "State_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.States", "State_Id", c => c.Int());
            CreateIndex("dbo.States", "State_Id");
            AddForeignKey("dbo.States", "State_Id", "dbo.States", "Id");
        }
    }
}
