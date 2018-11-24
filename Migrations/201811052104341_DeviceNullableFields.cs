namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceNullableFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "Battery", c => c.Int());
            AlterColumn("dbo.Devices", "RAM", c => c.Int());
            AlterColumn("dbo.Devices", "ProcessNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "ProcessNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "RAM", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "Battery", c => c.Int(nullable: false));
        }
    }
}
