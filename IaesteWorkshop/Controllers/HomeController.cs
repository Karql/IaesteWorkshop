using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IaesteWorkshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MenuItem = "index";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.MenuItem = "contact";

            return View();
        }

        public ActionResult Reviews()
        {
            ViewBag.MenuItem = "reviews";

            return View();
        }

        public ActionResult Single()
        {
            ViewBag.MenuItem = "single";

            return View();
        }

        public ActionResult Videos()
        {
            ViewBag.MenuItem = "videos";

            return View();
        }

        [ActionName("404")]
        public ActionResult Error404()
        {
            ViewBag.MenuItem = "404";

            return View("Error404");
        }
    }
}