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
            return View(log.UserWeights(Convert.ToInt32(Session["UserID"])));
        }

        //public ActionResult Weight()
        //{
        //    StatServices log = new StatServices();

        //}

        //public ActionResult Max()
        //{
        //    return PartialView();
        //}

        //public ActionResult Workouts()
        //{
        //    return PartialView();
        //}
    }
}
