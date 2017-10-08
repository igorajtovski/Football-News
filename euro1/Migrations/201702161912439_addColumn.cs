namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Statistic", "PName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Statistic", "PName");
        }
    }
}
