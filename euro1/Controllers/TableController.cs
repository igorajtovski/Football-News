using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using euro1.Models;
namespace euro1.Controllers
{
    public class TableController : Controller
    {
        
        public ActionResult Index()
        {
            List<Table> table = new List<Table>();
            MatchesRepository matchrep = new MatchesRepository();
            var allMatches = matchrep.GetAllMatches();
            TeamRepository teamsrep = new TeamRepository();
            var allTeams = teamsrep.GetAllTeams();
            foreach(Team t in allTeams)
            {
                Table result = new Table();
                result.Id = t.TeamId;
                result.TeamName = t.Name;
                int losses = 0;
                int draws = 0;
                int wins = 0;
                int goalsfor = 0;
                int goalsAgainst = 0;
                int points = 0;
                int Total = 0;
                var allTeamMAtches = allMatches.Where(k => k.HomeTeamId ==t.TeamId || k.GuestTeamId == t.TeamId);
                var allTeamHomeMatches = allTeamMAtches.Where(k => k.HomeTeamId == t.TeamId);
                var allTeamAwayMatches = allTeamMAtches.Where(k => k.GuestTeamId == t.TeamId);

                foreach (Match m in allTeamHomeMatches.Where(i=>i.Date<=DateTime.Now))
                {
                    
                            if (m.HomeGoals > m.AwayGoals)
                            {
                                wins++;
                                points += 3;
                            }
                            if (m.HomeGoals < m.AwayGoals)
                            {
                                losses++;
                                points += 0;
                            }
                            if (m.HomeGoals == m.AwayGoals)
                            {
                                draws++;
                                points += 1;
                            }
                            Total = wins + draws + losses;
                            goalsfor += m.HomeGoals;
                            goalsAgainst += m.AwayGoals;
                        }
                    
                

                foreach (Match m in allTeamAwayMatches.Where(i => i.Date <= DateTime.Now))
                {
                   
                            if (m.AwayGoals > m.HomeGoals)
                            {
                                wins++;
                                points += 3;
                            }
                            if (m.AwayGoals < m.HomeGoals)
                            {
                                losses++;
                                points += 0;
                            }
                            if (m.AwayGoals == m.HomeGoals)
                            {
                                draws++;
                                points += 1;
                            }
                            Total = wins + draws + losses;
                            goalsfor += m.AwayGoals;
                            goalsAgainst += m.HomeGoals;
                        }
                    
                
                result.Wins = wins;
                result.Losses = losses;
                result.Draws = draws;
                result.GoalsFor = goalsfor;
                result.GoalsAgains = goalsAgainst;
                result.Difference = goalsfor - goalsAgainst;
                result.Points = points;
                result.totoal = Total;
                table.Add(result);
            }
            ViewData["Result"] = table.OrderByDescending(k => k.Points).ThenByDescending(k => k.Difference);
            return View();
        }
        public ActionResult AllMatches(int? Id)
        {
            MatchesRepository db = new MatchesRepository();
            var matches = db.GetAllMatches().Where(i => i.HomeTeamId == Id || i.GuestTeamId == Id).OrderBy(i => i.Date);
            ViewData["MyMatches"] = matches;
            return View();
        }
    }
}