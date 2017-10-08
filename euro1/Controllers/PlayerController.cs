using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using euro1.Models;
using PagedList;
using PagedList.Mvc;

namespace euro1.Controllers
{
    public class PlayerController : Controller
    {
        private euroContext db = new euroContext();

        // GET: Player
        public ActionResult Index(string searchPlayer, int? page)
        {
           
            var players = from p in db.player
                          select p;
            if (!String.IsNullOrEmpty(searchPlayer))
            {
                players = db.player.Where(p => p.Name.Contains(searchPlayer) || p.LastName.Contains(searchPlayer)).Include(p => p.Team);
            }
            //int pageSize = 5;
            //int pageNumber = 1;
            return View(players.ToList().ToPagedList(page ?? 1,5));
        }

        public ActionResult ProfilePlayer(int ? Id)
        {
            PlayerRepository rep = new PlayerRepository();
            var player = rep.GetAllPlayers().Where(p => p.ID == Id);
            return View(player);

        }

        public ActionResult PlayerStatistic(int Id)
        {
            List<Scorrer> topscorrer = new List<Scorrer>();
            MatchReportRepository mdetailsrep = new MatchReportRepository();
            var matchdet = mdetailsrep.GetAllMatchDetails();
            PlayerRepository playerrep = new PlayerRepository();
            var allplayers = playerrep.GetAllPlayers().Where(i => i.ID == Id);
            foreach (Player p in allplayers)
            {
                Scorrer scorrer = new Scorrer();
                scorrer.Id = p.ID;
                scorrer.Name = p.LastName;
                scorrer.TeamName = p.Team.Name;
                scorrer.FName = p.Name;
                scorrer.Picture = p.Picture;
                int yellowCard = 0;
                int redCard = 0;
                int goals = 0;

                var players = matchdet.Where(g => g.ID == p.ID);
               // var statplayer = players.Where(i => i.ID == Id);
                foreach (MatchDetails pl in players)
                {
                    if (pl.StatisticId == 7)

                        goals++;
                    if (pl.StatisticId == 8)
                    {
                        yellowCard++;
                    }
                    if (pl.StatisticId == 11)
                    {
                        redCard++;
                    }
                }
                scorrer.Goals = goals;
                scorrer.YellowCard = yellowCard;
                scorrer.RedCard = redCard;
                topscorrer.Add(scorrer);
                ViewData["PlayerStat"] = topscorrer.OrderByDescending(k => k.Goals);
            }
            return View();

        }
        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name");
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Age,DateOfBirth,Picture,Club,Position,Number,Nationality,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.player.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,TeamId,Age,DateOfBirth,Nationality,Picture,Position,Number")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.player.Find(id);
            db.player.Remove(player);
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
