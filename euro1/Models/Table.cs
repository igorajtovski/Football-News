using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgains { get; set; }
        public int Difference { get; set; }
        public int Points { get; set; }
        public int totoal { get; set; }
    }
}