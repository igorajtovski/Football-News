using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using euro1.Models;
using Microsoft.Ajax.Utilities;

namespace euro1.Controllers
{
    public class MatchController : Controller
    {
        private euroContext db = new euroContext();

        // GET: Match
       // [Authorize(Roles = "Admin")]
        public ActionResult Index(string team)
        {
            euroContext db1 = new euroContext();
            MatchesRepository db = new MatchesRepository();
            TeamRepository teams = new TeamRepository();
            var matches = db.GetAllMatches().OrderBy(i=>i.Date);

            ViewBag.team1 = (from t in teams.GetAllTeams()
                             select t.Name);

            var model = from r in db.GetAllMatches()
                        where r.HomeTeam.Name == team || r.GuestTeam.Name == team
                        select r;
            ViewData["MyMatches"] = matches;
          
            return View(model);
           
        }

       public ActionResult Matches(int? Id)
        {
            MatchesRepository db = new MatchesRepository();
            var matches = db.GetAllMatches().Where(i => i.HomeTeamId == Id || i.GuestTeamId == Id).OrderBy(i => i.Date);
            ViewData["MyMatches"] = matches;
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            TeamRepository teamrep = new TeamRepository();
            List<SelectListItem> teamlist = new List<SelectListItem>();
           
            var myteams= teamrep.GetAllTeams();
            foreach (Team t in myteams)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = t.TeamId.ToString();
                sli.Text = t.Name;
               
                teamlist.Add(sli);
            }
            ViewData["Teams"] = teamlist;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Match match)
        {
            TeamRepository teamrep = new TeamRepository();
            List<SelectListItem> teamlist = new List<SelectListItem>();

            var myteams = teamrep.GetAllTeams();
            if (ModelState.IsValid)
            {
                foreach (Team t in myteams)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = t.TeamId.ToString();
                    sli.Text = t.Name;
                    teamlist.Add(sli);

                }
                db.matches.Add(match);
                db.SaveChanges();
                ViewData["Teams"] = teamlist;
                return RedirectToAction("Index");
            }
            return View();
          
        }
        // GET: Match/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }


        // GET: Match/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestTeamId = new SelectList(db.team, "TeamId", "Name", match.GuestTeamId);
            ViewBag.HomeTeamId = new SelectList(db.team, "TeamId", "Name", match.HomeTeamId);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,HomeTeamId,GuestTeamId,HomeGoals,AwayGoals,Date,Hours")] Match match, string checkbox)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(checkbox))
                {
                    match.Finish = true;
                }
                else
                {
                    match.Finish = false;
                }
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestTeamId = new SelectList(db.team, "TeamId", "Name", match.GuestTeamId);
            ViewBag.HomeTeamId = new SelectList(db.team, "TeamId", "Name", match.HomeTeamId);
            return View(match);
        }

        // GET: Match/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.matches.Find(id);
            db.matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
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
