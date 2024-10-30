namespace SportsClubMVC_1280429.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(nullable: false, maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Picture = c.String(),
                        Status = c.Boolean(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.SportsEntries",
                c => new
                    {
                        SportsEntriesId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        SportsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SportsEntriesId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportsId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.SportsId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        SportsId = c.Int(nullable: false, identity: true),
                        SportsTitle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SportsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SportsEntries", "SportsId", "dbo.Sports");
            DropForeignKey("dbo.SportsEntries", "PlayerId", "dbo.Players");
            DropIndex("dbo.SportsEntries", new[] { "SportsId" });
            DropIndex("dbo.SportsEntries", new[] { "PlayerId" });
            DropTable("dbo.Sports");
            DropTable("dbo.SportsEntries");
            DropTable("dbo.Players");
        }
    }
}
