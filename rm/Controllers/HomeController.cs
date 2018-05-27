using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rm.Models;
namespace rm.Controllers
{
    public class HomeController : Controller
    {
        RidgeContext ctx = new RidgeContext();

        public ActionResult Index()
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;

            return View();
        }
        public ActionResult About()
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            if (CurrentAccount.Login == null)
            {
                ViewBag.LogStatus = CurrentAccount.LogStatus;
                return View();
            }
            else
            {
                CurrentAccount.Login = null;
                CurrentAccount.LogStatus = "Log in";
                ViewBag.LogStatus = CurrentAccount.LogStatus;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Login(string loginTxt, string passTxt)
        {
            var users = ctx.Users.ToList();
            foreach (var user in users)
            {
                if (loginTxt == user.Login && passTxt == user.Password)
                {
                    CurrentAccount.Login = user.Login;
                    CurrentAccount.LogStatus = "Log out";
                    ViewBag.LogStatus = CurrentAccount.LogStatus;
                    return RedirectToAction("Office");
                }
            }
            ViewBag.LogStatus = CurrentAccount.LogStatus;
            ViewBag.Message = "Login doesn't match the password. Try again.";
            return View();
        }
        public ActionResult Office()
        {
            if (CurrentAccount.Login != null)
            {
                CurrentAccount.LogStatus = "Log out";
                ViewBag.LogStatus = CurrentAccount.LogStatus;
                return View(ctx.Users.Where(i => i.Login == CurrentAccount.Login).First());
            }
            else
            {
                ViewBag.LogStatus = CurrentAccount.LogStatus;
                return RedirectToAction("Login");
            }
        }

        public ActionResult GetUsers()
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;
            ViewBag.Message = "soska";

            return View();
        }
    }
}