namespace WebMVCApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
