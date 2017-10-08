namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAtributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Position", c => c.String());
            AddColumn("dbo.Player", "Asisits", c => c.Int(nullable: false));
            AddColumn("dbo.Scorrer", "FName", c => c.String());
            AddColumn("dbo.Scorrer", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scorrer", "Picture");
            DropColumn("dbo.Scorrer", "FName");
            DropColumn("dbo.Player", "Asisits");
            DropColumn("dbo.Player", "Position");
        }
    }
}
