using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final01._03._2021.Areas.admin1.Controllers
{
    public class homeController : Controller
    {
        // GET: admin1/home
        public ActionResult Index()
        {
            if(Session["add"]== null)
            {
                return RedirectToAction("login", "admin");
            }
            return View();
        }
    }
}