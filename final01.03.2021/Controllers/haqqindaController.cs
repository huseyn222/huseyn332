using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final01._03._2021.Models;

namespace final01._03._2021.Controllers
{
    public class haqqindaController : Controller
    {
        Entities db = new Entities();

        // GET: haqqinda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult haqqinda()
        {
            return View(db.haqqindas.FirstOrDefault());
        }
    }
}