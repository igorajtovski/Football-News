namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "Image");
        }
    }
}
