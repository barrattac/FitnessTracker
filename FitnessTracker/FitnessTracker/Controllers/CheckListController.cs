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
        public ActionResult Index(DateTime? date)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            DateTime now = DateTime.Now.Date;
            PlanningServices log = new PlanningServices();
            if (date != null)
            {
                now = Convert.ToDateTime(date);
            }
            return View(log.GetWorkoutPlan(Convert.ToInt32(Session["UserID"]), now));
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
