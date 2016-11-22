namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(unicode: false),
                        TimeSent = c.DateTime(nullable: false, precision: 0),
                        Body = c.String(unicode: false),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        PostDate = c.DateTime(nullable: false, precision: 0),
                        Body = c.String(unicode: false),
                        Upvotes = c.Int(nullable: false),
                        Downvotes = c.Int(nullable: false),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.posts", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.messages", "ChannelId", "dbo.channels");
            DropIndex("dbo.posts", new[] { "ThreadId" });
            DropIndex("dbo.messages", new[] { "ChannelId" });
            DropTable("dbo.Threads");
            DropTable("dbo.posts");
            DropTable("dbo.messages");
            DropTable("dbo.channels");
        }
    }
}
