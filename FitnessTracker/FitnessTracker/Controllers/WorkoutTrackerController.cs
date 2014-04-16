using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class WorkoutTrackerController : Controller
    {
        //
        // GET: /WorkoutTracker/

        public ActionResult Index()
        {
            return View();
        }

    }
}
