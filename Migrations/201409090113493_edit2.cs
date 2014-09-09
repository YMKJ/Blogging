namespace Blogging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "ApplicationUser_Id", newName: "User_Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
