using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collections.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "";

            return View();
        }
        [HttpGet]
        public PartialViewResult Filter()
        {
            return PartialView("Filter");
        }
    }
}