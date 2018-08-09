namespace SmartDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixattributename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "tirePressure", c => c.Single(nullable: false));
            DropColumn("dbo.Cars", "tirePresure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "tirePresure", c => c.Single(nullable: false));
            DropColumn("dbo.Cars", "tirePressure");
        }
    }
}
