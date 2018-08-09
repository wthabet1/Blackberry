namespace SmartDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addanametodomainmodelobject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Name", c => c.String());
            AddColumn("dbo.Fridges", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fridges", "Name");
            DropColumn("dbo.Cars", "Name");
        }
    }
}
