namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scorrer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Scorrer");
        }
    }
}
