namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message_Body : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Body", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Body");
        }
    }
}
