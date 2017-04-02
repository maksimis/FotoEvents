namespace FotoEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventModel", "ЕventModel_EventModelID", "dbo.EventModel");
            DropIndex("dbo.EventModel", new[] { "ЕventModel_EventModelID" });
            DropColumn("dbo.EventModel", "SmallSourse");
            DropColumn("dbo.EventModel", "Discriminator");
            DropColumn("dbo.EventModel", "ЕventModel_EventModelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventModel", "ЕventModel_EventModelID", c => c.Int());
            AddColumn("dbo.EventModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.EventModel", "SmallSourse", c => c.String());
            CreateIndex("dbo.EventModel", "ЕventModel_EventModelID");
            AddForeignKey("dbo.EventModel", "ЕventModel_EventModelID", "dbo.EventModel", "EventModelID");
        }
    }
}
