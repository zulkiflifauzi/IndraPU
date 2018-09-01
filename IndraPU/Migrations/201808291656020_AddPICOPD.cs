namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPICOPD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPD", "PIC", c => c.String(nullable: false));
            AddColumn("dbo.OPD", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPD", "PhoneNumber");
            DropColumn("dbo.OPD", "PIC");
        }
    }
}
