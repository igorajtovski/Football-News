namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventsID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateContent = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EventsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
