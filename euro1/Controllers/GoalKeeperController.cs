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
    public class GoalKeeperController : Controller
    {
        private euroContext db = new euroContext();

        // GET: GoalKeeper
        public ActionResult Index()
        {
            var goalKeepers = db.GoalKeepers.Include(g => g.Team);
            return View(goalKeepers.ToList());
        }

        // GET: GoalKeeper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalKeeper goalKeeper = db.GoalKeepers.Find(id);
            if (goalKeeper == null)
            {
                return HttpNotFound();
            }
            return View(goalKeeper);
        }

        // GET: GoalKeeper/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name");
            return View();
        }

        // POST: GoalKeeper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,PrimeniGolovi,Age,DateOfBirth,Played,Club,TeamId")] GoalKeeper goalKeeper)
        {
            if (ModelState.IsValid)
            {
                db.GoalKeepers.Add(goalKeeper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", goalKeeper.TeamId);
            return View(goalKeeper);
        }

        // GET: GoalKeeper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalKeeper goalKeeper = db.GoalKeepers.Find(id);
            if (goalKeeper == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", goalKeeper.TeamId);
            return View(goalKeeper);
        }

        // POST: GoalKeeper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,PrimeniGolovi,TeamId")] GoalKeeper goalKeeper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goalKeeper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.team, "TeamId", "Name", goalKeeper.TeamId);
            return View(goalKeeper);
        }

        // GET: GoalKeeper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalKeeper goalKeeper = db.GoalKeepers.Find(id);
            if (goalKeeper == null)
            {
                return HttpNotFound();
            }
            return View(goalKeeper);
        }

        // POST: GoalKeeper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoalKeeper goalKeeper = db.GoalKeepers.Find(id);
            db.GoalKeepers.Remove(goalKeeper);
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
