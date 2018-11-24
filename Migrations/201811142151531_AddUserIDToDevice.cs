namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIDToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Devices", "User_FirstName", c => c.String());
            AddColumn("dbo.Devices", "User_Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "User_Surname");
            DropColumn("dbo.Devices", "User_FirstName");
            DropColumn("dbo.Devices", "UserId");
        }
    }
}
