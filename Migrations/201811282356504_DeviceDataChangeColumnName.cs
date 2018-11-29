namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceDataChangeColumnName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DeviceDatas");
            AddColumn("dbo.DeviceDatas", "SendDateTime", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.DeviceDatas", "SendDateTime");
            DropColumn("dbo.DeviceDatas", "SendTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceDatas", "SendTime", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.DeviceDatas");
            DropColumn("dbo.DeviceDatas", "SendDateTime");
            AddPrimaryKey("dbo.DeviceDatas", "SendTime");
        }
    }
}
