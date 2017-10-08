using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Player>Players { get; set; }
        public virtual ICollection<Match>HomeMatches { get; set; }
        public virtual ICollection<Match>AwayMatches { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
