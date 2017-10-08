namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coachPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coach", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coach", "Picture");
        }
    }
}
