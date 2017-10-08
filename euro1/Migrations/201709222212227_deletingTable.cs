namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingTable : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventsID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.EventsID);
            
        }
    }
}
