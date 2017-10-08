using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class GoalKeeper
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Club { get; set; }
        public int Played { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int PrimeniGolovi { get; set; }
        
    }
}