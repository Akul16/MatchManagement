namespace MatchManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchesVenues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "VenueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "VenueId");
            AddForeignKey("dbo.Matches", "VenueId", "dbo.Venues", "VenueId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "VenueId", "dbo.Venues");
            DropIndex("dbo.Matches", new[] { "VenueId" });
            DropColumn("dbo.Matches", "VenueId");
        }
    }
}
