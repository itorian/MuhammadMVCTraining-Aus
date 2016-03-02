namespace ASPDotNetIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileInfoes", "Email", c => c.String());
            DropColumn("dbo.UserProfileInfoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfileInfoes", "UserId", c => c.String());
            DropColumn("dbo.UserProfileInfoes", "Email");
        }
    }
}
