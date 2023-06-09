namespace MatchManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matches");
        }
    }
}
