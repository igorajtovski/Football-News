using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class MatchDetails
    {
        [Key]
        public int MatchDetailsId { get; set; }
        public string Min { get; set; }
       // [ForeignKey("Scorrer")]
        public int ID { get; set; }
        public int MatchId { get; set; }
       // [ForeignKey("Statistics")]
        public int StatisticId { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public virtual Player Scorrer { get; set; }
       // public virtual Match Matches { get; set; }
        public virtual Statistic Statistics { get; set; }
       
    }
}
