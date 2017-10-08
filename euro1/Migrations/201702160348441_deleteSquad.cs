namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSquad : DbMigration
    {
        public override void Up()
        {
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
                    //  TeamId = c.Int(nullable: false),
                    PrimeniGolovi = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);
              //  .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
               // .Index(t => t.TeamId);
            
          
            
            
            CreateTable(
                "dbo.Player",
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
                        PostignatiGolovi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.GoalKeeper", "TeamId", "dbo.Team");
            //DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            //DopForeignKey("dbo.MatchDetails", "MatchId", "dbo.Match");
            //DropForeignKey("dbo.Match", "HomeTeamId", "dbo.Team");
          //  DropForeignKey("dbo.Match", "GuestTeamId", "dbo.Team");
            //DropIndex("dbo.Player", new[] { "TeamId" });
         ///   DropIndex("dbo.MatchDetails", new[] { "MatchId" });
          //  DropIndex("dbo.Match", new[] { "GuestTeamId" });
          //  DropIndex("dbo.Match", new[] { "HomeTeamId" });
          //  DropIndex("dbo.GoalKeeper", new[] { "TeamId" });
            DropTable("dbo.Player");
         //   DropTable("dbo.MatchDetails");
          //  DropTable("dbo.Match");
           // DropTable("dbo.Team");
            DropTable("dbo.GoalKeeper");
        }
    }
}
