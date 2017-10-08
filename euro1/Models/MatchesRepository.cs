using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class MatchesRepository
    {
        euroContext db = new euroContext();

        public List<Match> GetAllMatches()
        {
            return db.matches.ToList();
        
        }
    }
}