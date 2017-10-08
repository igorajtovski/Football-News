using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Statistic
    {
        public int StatisticId { get; set; }
        public string PName { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<MatchDetails> Matchdetails { get; set; }
    }
}