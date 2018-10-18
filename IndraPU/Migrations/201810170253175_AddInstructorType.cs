namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructorType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "Type");
        }
    }
}
