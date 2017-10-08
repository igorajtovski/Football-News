namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteMatchId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match");
            DropIndex("dbo.MatchDetails", new[] { "MatchId" });
            DropColumn("dbo.MatchDetails", "MatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchDetails", "MatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.MatchDetails", "MatchId");
            AddForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match", "MatchId", cascadeDelete: true);
        }
    }
}
