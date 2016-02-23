namespace WebMVCApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAddedRemoved1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false));
        }
    }
}
