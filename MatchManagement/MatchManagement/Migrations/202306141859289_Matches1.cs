namespace MatchManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matches1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "OpponentTeam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "OpponentTeam");
        }
    }
}
