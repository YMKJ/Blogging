namespace Blogging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hidden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Hidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Hidden");
            DropColumn("dbo.Comments", "Hidden");
        }
    }
}
