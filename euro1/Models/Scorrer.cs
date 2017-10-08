using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class Scorrer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Picture { get; set; }
        
        public string TeamName { get; set; }
        //public int Min { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int Goals { get; set; }
    }
}