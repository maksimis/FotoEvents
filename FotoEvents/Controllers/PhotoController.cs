using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FotoEvents.Models;

namespace FotoEvents.Controllers
{
    public class PhotoController : Controller
    {
        private EventContext db = new EventContext();

        // GET: PhotoModels
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        // GET: PhotoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoModel photoModel = db.Photos.Find(id);
            if (photoModel == null)
            {
                return HttpNotFound();
            }
            return View(photoModel);
        }

        // GET: PhotoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotoModelID,LargeSourse,SmallSourse,DateUploaded")] PhotoModel photoModel)
        {
            if (ModelState.IsValid)
            {
                db.Photos.Add(photoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoModel);
        }

        // GET: PhotoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoModel photoModel = db.Photos.Find(id);
            if (photoModel == null)
            {
                return HttpNotFound();
            }
            return View(photoModel);
        }

        // POST: PhotoModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoModelID,LargeSourse,SmallSourse,DateUploaded")] PhotoModel photoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoModel);
        }

        // GET: PhotoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoModel photoModel = db.Photos.Find(id);
            if (photoModel == null)
            {
                return HttpNotFound();
            }
            return View(photoModel);
        }

        // POST: PhotoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoModel photoModel = db.Photos.Find(id);
            db.Photos.Remove(photoModel);
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
