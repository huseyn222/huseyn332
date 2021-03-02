using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final01._03._2021.Models;

namespace final01._03._2021.Areas.admin1.Controllers
{


    public class adminController : Controller
    {
        Entities db = new Entities();
        // GET: admin1/admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(adminlogin adm)
        {

            adminlogin admi = db.adminlogins.FirstOrDefault(x=>x.name==adm.name);
            if (admi != null)
            {
                if (admi.password == adm.password)
                {
                    Session["add"] = admi;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}