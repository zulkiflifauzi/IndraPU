namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Date");
        }
    }
}
