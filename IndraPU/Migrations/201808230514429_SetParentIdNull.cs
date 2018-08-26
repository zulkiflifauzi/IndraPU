namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetParentIdNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OPD", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OPD", "ParentId", c => c.Int(nullable: false));
        }
    }
}
