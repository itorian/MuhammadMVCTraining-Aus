namespace WebMVCApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnInAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.Addresses", new[] { "Friend_Id" });
            RenameColumn(table: "dbo.Addresses", name: "Friend_Id", newName: "FriendId");
            AlterColumn("dbo.Addresses", "FriendId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "FriendId");
            AddForeignKey("dbo.Addresses", "FriendId", "dbo.Friends", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "FriendId", "dbo.Friends");
            DropIndex("dbo.Addresses", new[] { "FriendId" });
            AlterColumn("dbo.Addresses", "FriendId", c => c.Int());
            RenameColumn(table: "dbo.Addresses", name: "FriendId", newName: "Friend_Id");
            CreateIndex("dbo.Addresses", "Friend_Id");
            AddForeignKey("dbo.Addresses", "Friend_Id", "dbo.Friends", "Id");
        }
    }
}
