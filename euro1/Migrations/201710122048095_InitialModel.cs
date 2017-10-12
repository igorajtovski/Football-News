namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coach",
                c => new
                    {
                        CoachId = c.Int(nullable: false),
                        Name = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.CoachId)
                .ForeignKey("dbo.Team", t => t.CoachId)
                .Index(t => t.CoachId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        GuestTeamId = c.Int(nullable: false),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        Finish = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Team", t => t.GuestTeamId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.HomeTeamId, cascadeDelete: true)
                .Index(t => t.HomeTeamId)
                .Index(t => t.GuestTeamId);
            
            CreateTable(
                "dbo.MatchDetails",
                c => new
                    {
                        MatchDetailsId = c.Int(nullable: false, identity: true),
                        Min = c.String(),
                        ID = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        StatisticId = c.Int(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        GuestTeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchDetailsId)
                .ForeignKey("dbo.Player", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Statistic", t => t.StatisticId, cascadeDelete: true)
                .ForeignKey("dbo.Match", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.MatchId)
                .Index(t => t.StatisticId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        TeamId = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        Picture = c.String(),
                        Position = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Statistic",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.StatisticId);
            
            CreateTable(
                "dbo.GoalKeeper",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Club = c.String(),
                        Played = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        PrimeniGolovi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.ImageGallery",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Scorrer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FName = c.String(),
                        Picture = c.String(),
                        TeamName = c.String(),
                        YellowCard = c.Int(nullable: false),
                        RedCard = c.Int(nullable: false),
                        Goals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoalKeeper", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Coach", "CoachId", "dbo.Team");
            DropForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match");
            DropForeignKey("dbo.MatchDetails", "StatisticId", "dbo.Statistic");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.MatchDetails", "ID", "dbo.Player");
            DropForeignKey("dbo.Match", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Match", "GuestTeamId", "dbo.Team");
            DropIndex("dbo.GoalKeeper", new[] { "TeamId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.MatchDetails", new[] { "StatisticId" });
            DropIndex("dbo.MatchDetails", new[] { "MatchId" });
            DropIndex("dbo.MatchDetails", new[] { "ID" });
            DropIndex("dbo.Match", new[] { "GuestTeamId" });
            DropIndex("dbo.Match", new[] { "HomeTeamId" });
            DropIndex("dbo.Coach", new[] { "CoachId" });
            DropTable("dbo.Scorrer");
            DropTable("dbo.ImageGallery");
            DropTable("dbo.GoalKeeper");
            DropTable("dbo.Statistic");
            DropTable("dbo.Player");
            DropTable("dbo.MatchDetails");
            DropTable("dbo.Match");
            DropTable("dbo.Team");
            DropTable("dbo.Coach");
        }
    }
}
