namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStringLengthToDeviceName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "Name", c => c.String(nullable: false));
        }
    }
}
