using final01._03._2021.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace final01._03._2021.Areas.admin1.Controllers
{
    public class haqqindaController : Controller
    {
        Entities db = new Entities();

        // GET: admin1/haqqinda5

        public ActionResult Index()
        {
            return View(db.haqqindas.FirstOrDefault());
        }

        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                haqqinda sl3 = db.haqqindas.FirstOrDefault(x => x.ID == id);

                return View(sl3);
            }

            return View();
        }

        [HttpPost]

        public ActionResult edit(int? id, string header9, HttpPostedFileBase foto9)
        {
            haqqinda haqq = db.haqqindas.FirstOrDefault(x => x.ID == id);
            if (foto9 != null)
            {
                WebImage img = new WebImage(foto9.InputStream);
                FileInfo file = new FileInfo(foto9.FileName);
                string imgnamee = Guid.NewGuid() + file.Extension;
                img.Save("~/uploads/" + imgnamee);
                haqq.fotourl = "/uploads/" + imgnamee;
            }
            haqq.sozz = header9;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}