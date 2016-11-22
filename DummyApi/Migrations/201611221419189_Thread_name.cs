namespace DummyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thread_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.threads", "Name", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.threads", "Name");
        }
    }
}
