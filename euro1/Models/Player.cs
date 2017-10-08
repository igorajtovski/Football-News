using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public string Nationality { get; set; }
      
        public string Picture { get; set; }
       
        public string Position { get; set; }
      
        public int Number { get; set; }
        public virtual ICollection<MatchDetails> Matchdetails { get; set; }

    }
}