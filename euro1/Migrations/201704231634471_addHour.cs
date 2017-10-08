namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "Hours", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "Hours");
        }
    }
}
