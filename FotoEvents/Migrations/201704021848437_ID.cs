namespace FotoEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EventModel", name: "Club_ClubID", newName: "ClubID");
            RenameColumn(table: "dbo.EventModel", name: "Type_TypeID", newName: "TypeID");
            RenameIndex(table: "dbo.EventModel", name: "IX_Club_ClubID", newName: "IX_ClubID");
            RenameIndex(table: "dbo.EventModel", name: "IX_Type_TypeID", newName: "IX_TypeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EventModel", name: "IX_TypeID", newName: "IX_Type_TypeID");
            RenameIndex(table: "dbo.EventModel", name: "IX_ClubID", newName: "IX_Club_ClubID");
            RenameColumn(table: "dbo.EventModel", name: "TypeID", newName: "Type_TypeID");
            RenameColumn(table: "dbo.EventModel", name: "ClubID", newName: "Club_ClubID");
        }
    }
}
