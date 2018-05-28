using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rm.Models;

namespace rm.Controllers
{
    public static class CurrentAccount
    {
        public static string Login { get; set; }
        public static string LogStatus { get; set; }

        public static User user { get; set; }
        static CurrentAccount()
        {
            LogStatus = "Log in";
        }
    }
}