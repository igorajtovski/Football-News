namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MatchDetails", "Match_MatchId", "dbo.Match");
            DropIndex("dbo.MatchDetails", new[] { "Match_MatchId" });
            RenameColumn(table: "dbo.MatchDetails", name: "Match_MatchId", newName: "MatchId");
            AlterColumn("dbo.MatchDetails", "MatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.MatchDetails", "MatchId");
            AddForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match", "MatchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match");
            DropIndex("dbo.MatchDetails", new[] { "MatchId" });
            AlterColumn("dbo.MatchDetails", "MatchId", c => c.Int());
            RenameColumn(table: "dbo.MatchDetails", name: "MatchId", newName: "Match_MatchId");
            CreateIndex("dbo.MatchDetails", "Match_MatchId");
            AddForeignKey("dbo.MatchDetails", "Match_MatchId", "dbo.Match", "MatchId");
        }
    }
}
