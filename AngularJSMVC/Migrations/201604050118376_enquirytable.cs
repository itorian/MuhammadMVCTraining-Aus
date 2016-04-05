namespace AngularJSMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enquirytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enquiries");
        }
    }
}
