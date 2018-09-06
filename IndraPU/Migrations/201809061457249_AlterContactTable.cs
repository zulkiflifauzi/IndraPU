namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterContactTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "RepliedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "Reply", c => c.String());
            AddColumn("dbo.Contacts", "ReplyUserId", c => c.Int());
            CreateIndex("dbo.Contacts", "ReplyUserId");
            AddForeignKey("dbo.Contacts", "ReplyUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ReplyUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "ReplyUserId" });
            DropColumn("dbo.Contacts", "ReplyUserId");
            DropColumn("dbo.Contacts", "Reply");
            DropColumn("dbo.Contacts", "RepliedDate");
            DropColumn("dbo.Contacts", "CreatedDate");
            DropColumn("dbo.Contacts", "Status");
        }
    }
}
