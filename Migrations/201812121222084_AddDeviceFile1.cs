namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceFile1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceFiles", "DeviceId", "dbo.Devices");
            DropIndex("dbo.DeviceFiles", new[] { "DeviceId" });
            DropTable("dbo.DeviceFiles");
        }
    }
}
