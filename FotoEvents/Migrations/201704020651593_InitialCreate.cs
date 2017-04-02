namespace FotoEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClubID);
            
            CreateTable(
                "dbo.EventModel",
                c => new
                    {
                        EventModelID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Discription = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        Fornewbies = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Club_ClubID = c.Int(nullable: false),
                        Type_TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventModelID)
                .ForeignKey("dbo.Club", t => t.Club_ClubID, cascadeDelete: true)
                .ForeignKey("dbo.Type", t => t.Type_TypeID, cascadeDelete: true)
                .Index(t => t.Club_ClubID)
                .Index(t => t.Type_TypeID);
            
            CreateTable(
                "dbo.PhotoModel",
                c => new
                    {
                        PhotoModelID = c.Int(nullable: false, identity: true),
                        LargeSourse = c.String(nullable: false),
                        SmallSourse = c.String(),
                        DateUploaded = c.DateTime(nullable: false),
                        EventModel_EventModelID = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoModelID)
                .ForeignKey("dbo.EventModel", t => t.EventModel_EventModelID)
                .Index(t => t.EventModel_EventModelID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventModel", "Type_TypeID", "dbo.Type");
            DropForeignKey("dbo.PhotoModel", "EventModel_EventModelID", "dbo.EventModel");
            DropForeignKey("dbo.EventModel", "Club_ClubID", "dbo.Club");
            DropIndex("dbo.PhotoModel", new[] { "EventModel_EventModelID" });
            DropIndex("dbo.EventModel", new[] { "Type_TypeID" });
            DropIndex("dbo.EventModel", new[] { "Club_ClubID" });
            DropTable("dbo.Type");
            DropTable("dbo.PhotoModel");
            DropTable("dbo.EventModel");
            DropTable("dbo.Club");
        }
    }
}
