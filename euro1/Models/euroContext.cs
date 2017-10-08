using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class euroContext : DbContext
    {

        public DbSet<Player> player { get; set; }
        public DbSet<Team> team { get; set; }
        public DbSet<GoalKeeper> GoalKeepers { get; set; }
        public DbSet<Statistic>statistic { get; set; }
        public DbSet<Match> matches { get; set; }
        public DbSet<Coach> coaches { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }        protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
               modelBuilder.Entity<Match>()
                       .HasRequired(m => m.HomeTeam)
                       .WithMany(t => t.HomeMatches)
                       .HasForeignKey(m => m.HomeTeamId);
                       

               modelBuilder.Entity<Match>()
                       .HasRequired(m => m.GuestTeam)
                       .WithMany(t => t.AwayMatches)
                       .HasForeignKey(m => m.GuestTeamId);
              
               modelBuilder.Entity<Player>()
                       .HasRequired<Team>(s => s.Team)
                       .WithMany(t => t.Players)
                       .HasForeignKey(u => u.TeamId);


               // Configure CoachId as PK for Coach 
               // modelBuilder.Entity<Coach>()
               // .HasKey(s => s.CoachId);

               // Configure CoachId as FK for Coach 
               //modelBuilder.Entity<Team>()
               //.HasOptional(s => s.Coach) //Coach is optional 
               //.WithRequired(t => t.Team); // Create inverse relationship 




       }
        /*    protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               //Configure default schema 
               modelBuilder.HasDefaultSchema("");
               modelBuilder.Entity<Team>().Property(p => p.Name).IsRequired();
               modelBuilder.Entity<Player>().Property(p => p.Age).IsOptional();
               modelBuilder.Entity<Player>().Property(s => s.Ime)
                .HasColumnName("FirstName");
           }*/
        public System.Data.Entity.DbSet<euro1.Models.MatchDetails> MatchDetails { get; set; }

        public System.Data.Entity.DbSet<euro1.Models.Scorrer> Scorrers { get; set; }
    }
}