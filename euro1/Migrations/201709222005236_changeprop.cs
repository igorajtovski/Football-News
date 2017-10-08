namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "ImagePath", c => c.String());
            DropColumn("dbo.Events", "DateContent");
            DropColumn("dbo.Events", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Image", c => c.String());
            AddColumn("dbo.Events", "DateContent", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "ImagePath");
            DropColumn("dbo.Events", "Date");
        }
    }
}
