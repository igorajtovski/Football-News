using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Coach
    {
        [ForeignKey("Team")]
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public virtual Team Team { get; set; }
    }
}
