namespace FotoEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModel", "SmallSourse", c => c.String());
            AddColumn("dbo.EventModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.EventModel", "ЕventModel_EventModelID", c => c.Int());
            CreateIndex("dbo.EventModel", "ЕventModel_EventModelID");
            AddForeignKey("dbo.EventModel", "ЕventModel_EventModelID", "dbo.EventModel", "EventModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventModel", "ЕventModel_EventModelID", "dbo.EventModel");
            DropIndex("dbo.EventModel", new[] { "ЕventModel_EventModelID" });
            DropColumn("dbo.EventModel", "ЕventModel_EventModelID");
            DropColumn("dbo.EventModel", "Discriminator");
            DropColumn("dbo.EventModel", "SmallSourse");
        }
    }
}
