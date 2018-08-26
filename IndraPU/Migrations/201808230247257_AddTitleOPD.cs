namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleOPD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPD", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPD", "Title");
        }
    }
}
