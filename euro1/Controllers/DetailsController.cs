using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using euro1.Models;

namespace euro1.Controllers
{
    public class DetailsController : Controller
    {
        private euroContext db = new euroContext();

        // GET: Details
        public ActionResult Index(int ? Id)
        {
            
                var matchDetails = db.MatchDetails.Include(m => m.Scorrer).Include(m => m.Statistics).Where(k => k.MatchId == Id);
            return View(matchDetails.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchDetails matchDetails = db.MatchDetails.Find(id);
            if (matchDetails == null)
            {
                return HttpNotFound();
            }
            return View(matchDetails);
        }

        // GET: Details/Create
        public ActionResult Create(int ID)
        {
            List<SelectListItem> tlist = new List<SelectListItem>();
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            PlayerRepository  playerList = new PlayerRepository();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            var players = playerList.GetAllPlayers();
            TeamRepository trep = new TeamRepository();
            var teams = trep.GetAllTeams();
            foreach (Match m in mymatches.Where(i => i.HomeTeamId == ID && i.Date.Date == DateTime.Today.Date))
            {
                 SelectListItem sli2 = new SelectListItem();
                    SelectListItem sli1 = new SelectListItem();
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.MatchId.ToString();
                    sli.Text = m.HomeTeam.Name + " " + m.HomeGoals + "-" + m.AwayGoals + " " + m.GuestTeam.Name;
                    sli1.Value = m.HomeTeamId.ToString();
                    sli1.Text = m.HomeTeam.Name;
                    
                    matcheslist.Add(sli);
                    tlist.Add(sli1);
                
            }
            var pl = db.player.Where(i => i.TeamId == ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Name +" " + s.LastName + " " + s.Number
            });


            ViewData["Matches"] = matcheslist;
            ViewData["Teams"] = tlist;
          // ViewData["GuestTeams"] = tlist;
            ViewBag.MatchId = new SelectList(db.matches.Where(i => i.HomeTeamId == ID && i.Date == DateTime.Now), "MatchId", "MatchId");
            ViewBag.ID = new SelectList(pl, "Value","Text");
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "PName");
            ViewBag.HomeTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name");
          //  ViewBag.GuestTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchDetailsId,Content,MatchId,ID,Name,LastName,StatisticId,HomeTeamId,Min")] MatchDetails matchDetails, int ID)
        {
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            List<SelectListItem> tlist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            
            if (ModelState.IsValid)
            {
                foreach (Match m in mymatches.Where(i => i.HomeTeamId == ID))
                {
                    
                        SelectListItem sli1 = new SelectListItem();

                        SelectListItem sli = new SelectListItem();
                        sli.Value = m.MatchId.ToString();
                        sli.Text = m.HomeTeam.Name + " " + m.HomeGoals + "-" + m.AwayGoals + " " + m.GuestTeam.Name;
                        sli1.Value = m.HomeTeamId.ToString();
                        sli1.Text = m.HomeTeam.Name;
                       
                        matcheslist.Add(sli);
                        tlist.Add(sli1);
                    
                }
                  
                ViewData["Matches"] = matcheslist;
                ViewData["Teams"] = tlist;
               // ViewData["GuestTeams"] = tlist;
                db.MatchDetails.Add(matchDetails);
                db.SaveChanges();
                return RedirectToAction("Index", "Match");
            }
            
            ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            ViewBag.ID = new SelectList(db.player.Where(i => i.TeamId == ID), "ID", "Name", "LastName", matchDetails.ID);
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "PName", matchDetails.StatisticId);
            ViewBag.HomeTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name", matchDetails.HomeTeamId);
           // ViewBag.GuestTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name", matchDetails.GuestTeamId);
            return View();
        }
        public ActionResult Guests(int ID)
        {
            List<SelectListItem> tlist = new List<SelectListItem>();
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            foreach (Match m in mymatches.Where(i => i.GuestTeamId == ID && i.Date.Date == DateTime.Today.Date))
            {
                
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.MatchId.ToString();
                    sli.Text = m.HomeTeam.Name + " " + m.HomeGoals + "-" + m.AwayGoals + " " + m.GuestTeam.Name;
                    SelectListItem sli2 = new SelectListItem();
                    sli2.Value = m.GuestTeamId.ToString();
                    sli2.Text = m.GuestTeam.Name;
                    tlist.Add(sli2);
                    matcheslist.Add(sli);
                
            }
            var pl = db.player.Where(i => i.TeamId == ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Name + " " + s.LastName + " " + s.Number
            });
            ViewData["Matches"] = matcheslist;
            ViewData["GuestTeams"] = tlist;
            ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId");
            ViewBag.ID = new SelectList(pl, "Value", "Text");
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "PName");
            ViewBag.GuestTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guests([Bind(Include = "MatchDetailsId,Content,MatchId,ID,Name,LastName,StatisticId,GuestTeamId,Min")] MatchDetails matchDetails, int ID)
        {
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            List<SelectListItem> tlist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            if (ModelState.IsValid)
            {
                foreach (Match m in mymatches.Where(i => i.GuestTeamId == ID && i.Date == DateTime.Today))
                {
                    if (m.Date == DateTime.Now.Date)
                    {
                        SelectListItem sli2 = new SelectListItem();
                        SelectListItem sli = new SelectListItem();
                        sli.Value = m.MatchId.ToString();
                        sli.Text = m.HomeTeam.Name + " " + m.HomeGoals + "-" + m.AwayGoals + " " + m.GuestTeam.Name;
                        sli2.Value = m.GuestTeamId.ToString();
                        sli2.Text = m.GuestTeam.Name;
                        tlist.Add(sli2);
                        matcheslist.Add(sli);
                    }
                }
              
                ViewData["Matches"] = matcheslist;
                ViewData["GuestTeams"] = tlist;
                db.MatchDetails.Add(matchDetails);
                db.SaveChanges();
                return RedirectToAction("Index", "Match");
            }

            ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            ViewBag.ID = new SelectList(db.player.Where(i => i.TeamId == ID), "ID", "Name", "LastName", matchDetails.ID);
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "PName", matchDetails.StatisticId);
            ViewBag.GuestTeamId = new SelectList(db.team.Where(i => i.TeamId == ID), "TeamId", "Name", matchDetails.GuestTeamId);
            return View();
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchDetails matchDetails = db.MatchDetails.Find(id);
            if (matchDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            ViewBag.ID = new SelectList(db.player, "ID", "Ime", matchDetails.ID);
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "Picture", matchDetails.StatisticId);
            return View(matchDetails);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchDetailsId,Min,ID,StatisticId")] MatchDetails matchDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            ViewBag.ID = new SelectList(db.player, "ID", "Ime", matchDetails.ID);
            ViewBag.StatisticId = new SelectList(db.statistic, "StatisticId", "Picture", matchDetails.StatisticId);
            return View(matchDetails);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchDetails matchDetails = db.MatchDetails.Find(id);
            if (matchDetails == null)
            {
                return HttpNotFound();
            }
            return View(matchDetails);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchDetails matchDetails = db.MatchDetails.Find(id);
            db.MatchDetails.Remove(matchDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int Id)
        {
            MatchReportRepository db = new MatchReportRepository();
            var report = db.GetAllMatchDetails().Where(k => k.MatchDetailsId == Id).FirstOrDefault();
            return View(report);
        }

        public ActionResult Statistic()
        {
            List<Scorrer> topscorrer = new List<Scorrer>();
            MatchReportRepository mdetailsrep = new MatchReportRepository();
            var matchdet = mdetailsrep.GetAllMatchDetails();
            PlayerRepository playerrep = new PlayerRepository();
            var allplayers = playerrep.GetAllPlayers();
            foreach (Player p in allplayers) {
                Scorrer scorrer = new Scorrer();
                scorrer.Id = p.ID;
               
                scorrer.Name = p.LastName;
                scorrer.TeamName = p.Team.Name;
                scorrer.FName = p.Name;
                scorrer.Picture = p.Picture;
                
                int goals = 0;
                var players = matchdet.Where(g => g.ID == p.ID);
                foreach (MatchDetails pl in players)
                {
                    if(pl.StatisticId==7)
                    
                        goals++;
                    
                }
                scorrer.Goals = goals;
                topscorrer.Add(scorrer);
                ViewData["Scorrer"] = topscorrer.Where(g => g.Goals > 0).OrderByDescending(k => k.Goals);
            }
            return View();
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
