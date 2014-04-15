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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            PlanningServices log = new PlanningServices();
            return View(log.GetWorkoutPlan(Convert.ToInt32(Session["UserID"])));
        }

        public ActionResult DayPlanner(DateTime date)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            PlanningServices log = new PlanningServices();
            return View(log.GetWorkoutPlan(Convert.ToInt32(Session["UserID"]), date));
        }

        [HttpGet]
        public ActionResult AddWorkout(DateTime date)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            PlanningServices log = new PlanningServices();
            return View(new WorkoutFM(Convert.ToInt32(Session["UserID"]), date));
        }
        [HttpPost]
        public ActionResult AddWorkout(WorkoutFM workout, FormCollection collection)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            PlanningServices log = new PlanningServices();
            workout.UserID = Convert.ToInt32(Session["UserID"]);
            log.AddWorkout(workout);
            return RedirectToAction("DayPlanner", workout.PlanDate);
        }
    }
}
