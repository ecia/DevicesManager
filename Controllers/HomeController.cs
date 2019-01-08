using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesManager.Models;
using System.Web.Mvc;


namespace DevicesManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About: ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Author: ";

            return View();
        }
    }
}