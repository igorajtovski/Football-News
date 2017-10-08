using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public class TeamRepository
    {
        euroContext db = new euroContext();

        public List<Team> GetAllTeams()
        {
            return db.team.Include("Coach").ToList();

        }
    }
}