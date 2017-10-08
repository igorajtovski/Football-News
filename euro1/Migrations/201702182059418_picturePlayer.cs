namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picturePlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Picture");
        }
    }
}
