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
    public class CoachController : Controller
    {
        private euroContext db = new euroContext();

        // GET: Coach
        public ActionResult Index()
        {
            var coaches = db.coaches.Include(c => c.Team);
            return View(coaches.ToList());
        }

        // GET: Coach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // GET: Coach/Create
        public ActionResult Create()
        {
            ViewBag.CoachId = new SelectList(db.team, "TeamId", "Name");
            return View();
        }

        // POST: Coach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoachId,Name")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.coaches.Add(coach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachId = new SelectList(db.team, "TeamId", "Name", coach.CoachId);
            return View(coach);
        }

        // GET: Coach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.team, "TeamId", "Name", coach.CoachId);
            return View(coach);
        }

        // POST: Coach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoachId,Name")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.team, "TeamId", "Name", coach.CoachId);
            return View(coach);
        }

        // GET: Coach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: Coach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coach coach = db.coaches.Find(id);
            db.coaches.Remove(coach);
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
