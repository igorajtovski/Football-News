using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class MatchReportRepository
    {
        euroContext db = new euroContext();

        public List<MatchDetails> GetAllMatchDetails()
        {
            return db.MatchDetails.ToList();

        }
    }
}