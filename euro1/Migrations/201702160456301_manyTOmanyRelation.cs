namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyTOmanyRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistic",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.StatisticId);
            
            AddColumn("dbo.MatchDetails", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.MatchDetails", "StatisticId", c => c.Int(nullable: false));
            CreateIndex("dbo.MatchDetails", "ID");
            CreateIndex("dbo.MatchDetails", "StatisticId");
           // AddForeignKey("dbo.MatchDetails", "ID", "dbo.Player", "ID", cascadeDelete: true);
          //  AddForeignKey("dbo.MatchDetails", "StatisticId", "dbo.Statistic", "StatisticId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchDetails", "StatisticId", "dbo.Statistic");
            DropForeignKey("dbo.MatchDetails", "ID", "dbo.Player");
            DropIndex("dbo.MatchDetails", new[] { "StatisticId" });
            DropIndex("dbo.MatchDetails", new[] { "ID" });
            DropColumn("dbo.MatchDetails", "StatisticId");
            DropColumn("dbo.MatchDetails", "ID");
            DropTable("dbo.Statistic");
        }
    }
}
