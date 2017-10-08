using euro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace euro1.Controllers
{
    public class HomeController : Controller
    {
        private euroContext db = new euroContext();

        // GET: Event
        public ActionResult Index()
        {
            List<ImageGallery> all = new List<ImageGallery>();

            // Here MyDatabaseEntities is our datacontext
            using (euroContext dc = new euroContext())
            {
                all = dc.ImageGalleries.OrderByDescending(m=>m.Date.Hour).Take(1).ToList();
                
            }
            return View(all);
        }

    }
    
}