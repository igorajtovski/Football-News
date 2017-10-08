using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Match
    {
        MatchReportRepository db = new MatchReportRepository();
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public bool Finish { get; set; }
        public DateTime Date { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
        public virtual ICollection<MatchDetails> MatchDetail { get; set; }

       

    }
}
