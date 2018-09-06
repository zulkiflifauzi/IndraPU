namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterContactTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "RepliedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "RepliedDate", c => c.DateTime(nullable: false));
        }
    }
}
