namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hourProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Match", "Hours", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Match", "Hours", c => c.String());
        }
    }
}
