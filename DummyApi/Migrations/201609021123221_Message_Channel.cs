namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message_Channel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(unicode: false),
                        TimeSent = c.DateTime(nullable: false, precision: 0),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ChannelId", "dbo.Channels");
            DropIndex("dbo.Messages", new[] { "ChannelId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Channels");
        }
    }
}
