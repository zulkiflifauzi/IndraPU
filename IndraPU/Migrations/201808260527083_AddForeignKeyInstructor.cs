namespace IndraPU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyInstructor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Instructors", "StateId");
            CreateIndex("dbo.Instructors", "CityId");
            AddForeignKey("dbo.Instructors", "CityId", "dbo.Cities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Instructors", "StateId", "dbo.States", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "StateId", "dbo.States");
            DropForeignKey("dbo.Instructors", "CityId", "dbo.Cities");
            DropIndex("dbo.Instructors", new[] { "CityId" });
            DropIndex("dbo.Instructors", new[] { "StateId" });
        }
    }
}
