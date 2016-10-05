namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posts_upvote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "Upvotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.posts", "Upvotes");
        }
    }
}
