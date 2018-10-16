namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeToFormOPD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPD", "Form", c => c.String(nullable: false));
            DropColumn("dbo.OPD", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OPD", "Type", c => c.String(nullable: false));
            DropColumn("dbo.OPD", "Form");
        }
    }
}
