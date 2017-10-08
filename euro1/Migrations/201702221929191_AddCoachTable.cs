namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoachTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coach",
                c => new
                    {
                        CoachId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CoachId)
                .ForeignKey("dbo.Team", t => t.CoachId)
                .Index(t => t.CoachId);
            
            AddColumn("dbo.Player", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coach", "CoachId", "dbo.Team");
            DropIndex("dbo.Coach", new[] { "CoachId" });
            DropColumn("dbo.Player", "Number");
            DropTable("dbo.Coach");
        }
    }
}
