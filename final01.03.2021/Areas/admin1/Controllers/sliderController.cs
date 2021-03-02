using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using final01._03._2021.Models;

namespace final01._03._2021.Areas.admin1.Controllers
{
    public class sliderController : Controller
    {


        Entities db = new Entities();

        // GET: admin1/slider
        public ActionResult Index()
        {
            return View(db.slide1.FirstOrDefault());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
            slide1 sl2 = db.slide1.FirstOrDefault(x => x.ID == id);

                return View(sl2);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int? id, string header, string description, HttpPostedFileBase foto)
        {
            slide1 sl1 = db.slide1.FirstOrDefault(x => x.ID == id);
            if(foto != null)
            {
                WebImage img = new WebImage(foto.InputStream);
                FileInfo file = new FileInfo(foto.FileName);
                string imgname = Guid.NewGuid() + file.Extension;
                img.Save("~/uploads/" + imgname);
                sl1.photourl = "/uploads/" + imgname;
            }
            sl1.soz1 = header;
            sl1.soz2 = description;
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }
    }
}