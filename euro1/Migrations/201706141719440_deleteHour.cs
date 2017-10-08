namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteHour : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Match", "Hours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Match", "Hours", c => c.DateTime(nullable: false));
        }
    }
}
