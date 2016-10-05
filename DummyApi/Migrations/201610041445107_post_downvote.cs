namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post_downvote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "Downvotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.posts", "Downvotes");
        }
    }
}
