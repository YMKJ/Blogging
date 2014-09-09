namespace Blogging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "ApplicationUser_Id");
            AddColumn("dbo.Posts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UserId");
            RenameColumn(table: "dbo.Posts", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
