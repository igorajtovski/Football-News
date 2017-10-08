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
    public class MatchDetailsController : Controller
    {
        private euroContext db = new euroContext();

        // GET: MatchDetails
        public ActionResult Index()
        {
            MatchReportRepository db = new MatchReportRepository();
            var matchdetails = db.GetAllMatchDetails();
            ViewData["Reports"] = matchdetails;
            return View();
        }

        public ActionResult Add()
        {
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            foreach (Match m in mymatches)
            {
                if (m.Date == DateTime.Now.Date)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.MatchId.ToString();
                    sli.Text = m.HomeTeam.Name + " " + m.HomeGoals + "-" + m.AwayGoals + " " + m.GuestTeam.Name;
                    matcheslist.Add(sli);
                }
            }
            ViewData["Matches"] = matcheslist;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(MatchDetails matchdetails)
        {
            List<SelectListItem> matcheslist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();
            foreach (Match m in mymatches)
            {
                if (m.Date == DateTime.Now.Date)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.MatchId.ToString();
                    sli.Text = m.HomeTeam.Name + "(" + m.HomeGoals + "-" + m.AwayGoals + ")" + m.GuestTeam.Name;
                    matcheslist.Add(sli);
                }
                }
                db.MatchDetails.Add(matchdetails);
                db.SaveChanges();
                ViewData["Matches"] = matcheslist;
                return View();
            }
        
        public ActionResult View(int Id)
        {
            MatchReportRepository db = new MatchReportRepository();
            var report = db.GetAllMatchDetails().Where(k=>k.MatchDetailsId== Id).FirstOrDefault();
            return View(report);
        }

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
           // ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            return View(matchDetails);
        }

        
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchDetailsId,Content,MatchId")] MatchDetails matchDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.MatchId = new SelectList(db.matches, "MatchId", "MatchId", matchDetails.MatchId);
            return View(matchDetails);
        }


    }
}
