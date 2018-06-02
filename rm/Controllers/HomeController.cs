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
            ViewBag.message = "nothing";
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
                    CurrentAccount.user = user;
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

        public ActionResult Ridges()
        {
            if(CurrentAccount.Login == null)
            {
                return RedirectToAction("Login");
            }


            ViewBag.LogStatus = CurrentAccount.LogStatus;
            
            var ridge_list = ctx.Ridges.Where(i => i.Owner_idUser == CurrentAccount.user.idUser).ToList();
            ViewBag.ridge_list = ridge_list;

            var lamps = new List<Lapm>();
            foreach (var item in ridge_list)
                lamps.Add(item.Lapms.Where(i => i.Toggle == 1).First());

            ViewBag.lamps = lamps;

            return View();
        }
       
        public ActionResult Details(int idRidge)
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;

            var detalized_ridge = ctx.Ridges.Find(idRidge);
            var lamps = detalized_ridge.Lapms;
            
            ViewBag.Scenario = detalized_ridge.Scenario;
            ViewBag.lamps = detalized_ridge.Lapms;
            ViewBag.scenarios = ctx.Scenarios;

            ViewBag.active_lamp = lamps.Where(i => i.Toggle == 1).First();

            return View(detalized_ridge);
        }
       [HttpPost] public ActionResult Change_lamp(int new_lamp)
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;

            var newLamp = ctx.Lapms.Find(new_lamp);
            var ridge = newLamp.Ridge;

            foreach (var lamp in ridge.Lapms)
                if (lamp.Toggle == 1) lamp.Toggle = 0;
            newLamp.Toggle = 1;

            ctx.SaveChanges();

            return RedirectToAction("Details", new { idRidge = newLamp.Ridge.idRidge });
        }

        [HttpPost]
        public ActionResult Change_scenario(int new_scenario, int curr_ridge)
        {
            ViewBag.LogStatus = CurrentAccount.LogStatus;

            var ridge = ctx.Ridges.Find(curr_ridge);

            ridge.idScenario = new_scenario;

            ctx.SaveChanges();

            return RedirectToAction("Details", new { idRidge = ridge.idRidge });
        }

    }
}