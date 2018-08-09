namespace SmartDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fluidLevel = c.String(),
                        tirePresure = c.Single(nullable: false),
                        engineTemperature = c.Single(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Fridges",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        temperature = c.Single(nullable: false),
                        iceLevel = c.String(),
                        defrostAlarm = c.Boolean(nullable: false),
                        waterLeaks = c.Boolean(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fridges");
            DropTable("dbo.Cars");
        }
    }
}
