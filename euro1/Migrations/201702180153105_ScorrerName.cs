namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScorrerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scorrer", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scorrer", "Name");
        }
    }
}
