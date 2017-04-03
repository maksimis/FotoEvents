using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FotoEvents.Models;
using System.IO;

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

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\large", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
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
