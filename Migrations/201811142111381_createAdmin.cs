namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [userInformations_FirstName], [userInformations_Surname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
            VALUES (N'79e2d0ab-4533-4656-b074-062e0baf17b0', N'Admin', N'Admin', N'admin@admin.com', 0, N'APx+raqE+vnWTyovHmu2p3wt+iKCsV6pqGZhzZUbmbK5PYhjEHWEEiVTwvUqAHdsGQ==', N'fb93b88a-96ab-45ff-a915-25f684c825b1', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')");
            Sql("INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'79e2d0ab-4533-4656-b074-062e0baf17b0', N'1')");
        }
        
        public override void Down()
        {
        }
    }
}
