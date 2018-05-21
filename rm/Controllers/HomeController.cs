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
        RidgeContext ctx;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string loginTxt, string passTxt)
        {
            ctx = new RidgeContext();

            ViewBag.Message = loginTxt + " " + passTxt;

            var users = ctx.Users.ToList();
           
            foreach (var user in users)
            {
                if (loginTxt == user.Login && passTxt == user.Password)
                {
                    return Redirect("/Home/Index");
                    //хмм, а як вивести на цю сторінку щось ?0\
                }
            }
            
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "login page";
            
            return View();
            
        }
        public ActionResult GetUsers()
        {
            ViewBag.Message = "soska";

            return View();
        }
    }
}