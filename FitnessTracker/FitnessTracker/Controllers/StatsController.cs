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
            Graphs graphs = log.GetGraphs(Convert.ToInt32(Session["UserID"]));
            return View(log.GetGraphs(Convert.ToInt32(Session["UserID"])));
        }

        [HttpGet]
        public ActionResult UpdateWeight()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateWeight(StatsFM fm)
        {
            fm.UserID = Convert.ToInt32(Session["UserID"]);
            StatServices log = new StatServices();
            if (fm.Weight > 0 && log.UpdeteWeight(fm))
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Sorry, but your weight was not updated.";
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePushupMax()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePushupMax(StatsFM fm)
        {
            fm.UserID = Convert.ToInt32(Session["UserID"]);
            StatServices log = new StatServices();
            if (fm.PushupMax > 0 && log.UpdetePushupMax(fm))
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Sorry, but your pushup max was not updated.";
            return View();
        }

        [HttpGet]
        public ActionResult UpdateSitupMax()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSitupMax(StatsFM fm)
        {
            fm.UserID = Convert.ToInt32(Session["UserID"]);
            StatServices log = new StatServices();
            if (fm.SitupMax > 0 && log.UpdeteSitupMax(fm))
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Sorry, but your situp max was not updated.";
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePullupMax()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account", new { });
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePullupMax(StatsFM fm)
        {
            fm.UserID = Convert.ToInt32(Session["UserID"]);
            StatServices log = new StatServices();
            if (fm.PullupMax > 0 && log.UpdetePullupMax(fm))
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Sorry, but your pullup max was not updated.";
            return View();
        }
    }
}