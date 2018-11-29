namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDevicesDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceDatas",
                c => new
                    {
                        SendTime = c.DateTime(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        Battery = c.Int(),
                        CPU = c.Double(),
                        RAM = c.Double(),
                        ProcessNumber = c.Int(),
                    })
                .PrimaryKey(t => t.SendTime)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            DropColumn("dbo.Devices", "Battery");
            DropColumn("dbo.Devices", "CPU");
            DropColumn("dbo.Devices", "RAM");
            DropColumn("dbo.Devices", "ProcessNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "ProcessNumber", c => c.Int());
            AddColumn("dbo.Devices", "RAM", c => c.Int());
            AddColumn("dbo.Devices", "CPU", c => c.String());
            AddColumn("dbo.Devices", "Battery", c => c.Int());
            DropForeignKey("dbo.DeviceDatas", "DeviceId", "dbo.Devices");
            DropIndex("dbo.DeviceDatas", new[] { "DeviceId" });
            DropTable("dbo.DeviceDatas");
        }
    }
}
