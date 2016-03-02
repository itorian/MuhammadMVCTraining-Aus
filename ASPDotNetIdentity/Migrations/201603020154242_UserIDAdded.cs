namespace ASPDotNetIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIDAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileInfoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfileInfoes", "UserId");
        }
    }
}
