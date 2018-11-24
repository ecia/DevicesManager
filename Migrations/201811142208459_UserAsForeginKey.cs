namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAsForeginKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Devices", "ApplicationUser_Id");
            AddForeignKey("dbo.Devices", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Devices", "User_FirstName");
            DropColumn("dbo.Devices", "User_Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "User_Surname", c => c.String());
            AddColumn("dbo.Devices", "User_FirstName", c => c.String());
            DropForeignKey("dbo.Devices", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Devices", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Devices", "ApplicationUser_Id");
        }
    }
}
