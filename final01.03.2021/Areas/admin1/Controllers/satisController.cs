using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using final01._03._2021.Models;

namespace final01._03._2021.Areas.admin1.Controllers
{
    public class satisController : Controller
    {
        private Entities db = new Entities();

        // GET: admin1/satis
        public ActionResult Index()
        {
            return View(db.satis.ToList());
        }

        // GET: admin1/satis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sati sati = db.satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            return View(sati);
        }

        // GET: admin1/satis/Create
        public ActionResult Create()
        {
                        if (db.satis.Count() >= 1000)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: admin1/satis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(sati sati, HttpPostedFileBase foto)
        {

            if (ModelState.IsValid)
            {

                WebImage img = new WebImage(foto.InputStream);
                FileInfo file = new FileInfo(foto.FileName);
                string imgname = Guid.NewGuid() + file.Extension;
                img.Save("~/uploads/" + imgname);
                sati.photourl = "/uploads/" + imgname;
                db.satis.Add(sati);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: admin1/satis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sati sati = db.satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            return View(sati);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string header, int qiymet, HttpPostedFileBase foto)
        {
            sati sa1 = db.satis.FirstOrDefault(x=>x.ID==id);

            if (foto != null)
            {
                WebImage img = new WebImage(foto.InputStream);
                FileInfo file = new FileInfo(foto.FileName);
                string imgname = Guid.NewGuid() + file.Extension;
                img.Save("~/uploads/" + imgname);
                sa1.photourl = "/uploads/" + imgname;
            }
            sa1.soz1 = header;
            sa1.qiymet = qiymet;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // POST: admin1/satis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,photourl,soz1,qiymet")] sati sati)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sati).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sati);
        //}

        // GET: admin1/satis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sati sati = db.satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            return View(sati);
        }

        // POST: admin1/satis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sati sati = db.satis.Find(id);
            db.satis.Remove(sati);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
