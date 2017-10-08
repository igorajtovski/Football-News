namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Name", c => c.String());
            AddColumn("dbo.Player", "LastName", c => c.String());
            DropColumn("dbo.Player", "Ime");
            DropColumn("dbo.Player", "Prezime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "Prezime", c => c.String());
            AddColumn("dbo.Player", "Ime", c => c.String());
            DropColumn("dbo.Player", "LastName");
            DropColumn("dbo.Player", "Name");
        }
    }
}
