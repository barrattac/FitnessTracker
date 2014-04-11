using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FitnessTracker.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserFM user)
        {
            AccountServices log = new AccountServices();
            if (log.ValidateNewUser(user))
            {
                Session["UserID"] = log.CreateUser(user);
                return RedirectToAction("Index", "Home", new { });
            }
            else
            {
                ViewBag.ErrorMessage = log.GetErrorNewUser(user);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView("_Login");
        }
        [HttpPost]
        public ActionResult Login(UserFM user)
        {
            AccountServices log = new AccountServices();
            Session["UserID"] = log.Login(user);
            if (Convert.ToInt32(Session["UserID"]) == 0)
            {
                Session["UserID"] = null;
                ViewBag.ErrorMessage = "Invalid credentials.";
                return View("Register");
            }
            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Register");
        }
    }
}
