namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchDetails", "HomeTeamId", c => c.Int(nullable: false));
            AddColumn("dbo.MatchDetails", "GuestTeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MatchDetails", "GuestTeamId");
            DropColumn("dbo.MatchDetails", "HomeTeamId");
        }
    }
}
