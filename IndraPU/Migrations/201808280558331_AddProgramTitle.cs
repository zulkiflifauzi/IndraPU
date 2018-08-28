namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Title");
        }
    }
}
