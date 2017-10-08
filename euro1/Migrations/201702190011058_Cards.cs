namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scorrer", "YellowCard", c => c.Int(nullable: false));
            AddColumn("dbo.Scorrer", "RedCard", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scorrer", "RedCard");
            DropColumn("dbo.Scorrer", "YellowCard");
        }
    }
}
