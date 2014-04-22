using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FitnessTracker.Controllers
{
    public class CheckListController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            PlanningServices log = new PlanningServices();
            return View(log.GetWorkoutPlan(Convert.ToInt32(Session["UserID"]), DateTime.Now.Date));
        }

        public ActionResult MarkComplete(List<WorkoutVM> workouts)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            WorkoutTrackingStatus log = new WorkoutTrackingStatus();
            log.UpdateWorkouts(workouts);
            return RedirectToAction("Index");
        }

    }
}
