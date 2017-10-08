namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAtrName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchDetails", "Min", c => c.String());
            DropColumn("dbo.MatchDetails", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchDetails", "Content", c => c.String());
            DropColumn("dbo.MatchDetails", "Min");
        }
    }
}
