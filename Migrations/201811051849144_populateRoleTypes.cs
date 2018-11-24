namespace DevicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateRoleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("delete from AspNetRoles where id=0;");
            Sql("Insert INTO AspNetRoles (Id, Name) values (0, 'User');");
            Sql("Insert INTO AspNetRoles (Id, Name) values (1, 'Admin');");
        }
        
        public override void Down()
        {
        }
    }
}
