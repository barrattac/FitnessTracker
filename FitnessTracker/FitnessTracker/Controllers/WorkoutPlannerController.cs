using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FitnessTracker.Controllers
{
    public class WorkoutPlannerController : Controller
    {
        public ActionResult Index()
        {
            //if (Session["UserID"] == null)
            //{
            //    return RedirectToAction("Register", "Account", new { });
            //}
            PlanningServices log = new PlanningServices();
            return View(log.GetFirstDay());
        }

    }
}
