namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userNameAndSurnameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "userInformations_FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "userInformations_Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "userInformations_Surname", c => c.String());
            AlterColumn("dbo.AspNetUsers", "userInformations_FirstName", c => c.String());
        }
    }
}
