namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAsForeginKeyChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "UserId", c => c.Int(nullable: false));
        }
    }
}
