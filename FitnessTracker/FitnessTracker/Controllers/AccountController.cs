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
                return View("Index", "Home", new { });
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
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserFM user)
        {
            AccountServices log = new AccountServices();
            return View();
        }
    }
}
