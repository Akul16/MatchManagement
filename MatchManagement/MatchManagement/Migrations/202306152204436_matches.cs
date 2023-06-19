namespace MatchManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "OpponentTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "OpponentTeamId");
            AddForeignKey("dbo.Matches", "OpponentTeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
            DropColumn("dbo.Matches", "OpponentTeam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "OpponentTeam", c => c.String());
            DropForeignKey("dbo.Matches", "OpponentTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "OpponentTeamId" });
            DropColumn("dbo.Matches", "OpponentTeamId");
        }
    }
}
