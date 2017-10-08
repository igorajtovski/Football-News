namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScorrerTeamName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scorrer", "TeamName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scorrer", "TeamName");
        }
    }
}
