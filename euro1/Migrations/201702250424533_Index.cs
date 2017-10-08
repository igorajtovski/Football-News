namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Index : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchDetails", "Match_MatchId", c => c.Int());
            CreateIndex("dbo.MatchDetails", "Match_MatchId");
            AddForeignKey("dbo.MatchDetails", "Match_MatchId", "dbo.Match", "MatchId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchDetails", "Match_MatchId", "dbo.Match");
            DropIndex("dbo.MatchDetails", new[] { "Match_MatchId" });
            DropColumn("dbo.MatchDetails", "Match_MatchId");
        }
    }
}
