namespace FotoEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problem2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PhotoModel", name: "EventModel_EventModelID", newName: "Event_EventModelID");
            RenameIndex(table: "dbo.PhotoModel", name: "IX_EventModel_EventModelID", newName: "IX_Event_EventModelID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PhotoModel", name: "IX_Event_EventModelID", newName: "IX_EventModel_EventModelID");
            RenameColumn(table: "dbo.PhotoModel", name: "Event_EventModelID", newName: "EventModel_EventModelID");
        }
    }
}
