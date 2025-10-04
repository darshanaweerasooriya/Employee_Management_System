using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

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

        // Login action
        public ActionResult Login()
        {
            // Specify the path to the view inside Views/Account
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            if (Email == "admin@example.com" && Password == "123")
            {
                Session["User"] = Email;
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Invalid email or password";
            return View("~/Views/Account/Login.cshtml");
        }
    }
}