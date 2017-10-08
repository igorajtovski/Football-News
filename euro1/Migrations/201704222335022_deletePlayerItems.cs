namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePlayerItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Nationality", c => c.String());
            DropColumn("dbo.Player", "Club");
            DropColumn("dbo.Player", "Played");
            DropColumn("dbo.Player", "PostignatiGolovi");
            DropColumn("dbo.Player", "Asisits");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "Asisits", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "PostignatiGolovi", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "Played", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "Club", c => c.String());
            DropColumn("dbo.Player", "Nationality");
        }
    }
}
