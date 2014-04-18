using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FitnessTracker.Controllers
{
    public class StatsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            StatServices log = new StatServices();
            return View(new Graphs(log.UserWeights(Convert.ToInt32(Session["UserID"]))));
        }
    }
}
