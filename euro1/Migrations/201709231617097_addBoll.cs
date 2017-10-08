namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBoll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "Finish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "Finish");
        }
    }
}
