namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLatLongState : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "Latitude", c => c.Double());
            AlterColumn("dbo.States", "Longitude", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "Longitude", c => c.Long());
            AlterColumn("dbo.States", "Latitude", c => c.Long());
        }
    }
}
