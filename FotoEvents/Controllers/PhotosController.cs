using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FotoEvents.Models;
using PagedList;

namespace FotoEvents.Controllers
{
    public class PhotosController : Controller
    {
        private EventContext db = new EventContext();

        // GET: Events
        public ActionResult Index(int? page)
        {
            int pageSize = 12; //Максимальное количество элементов на странице, для ToPagedList
            int pageNumber = (page ?? 1);
            IEnumerable<EventModel> events = db.Events.OrderBy(x => x.DateTime).ToList();
            var photos = db.Photos.ToList();
            var eventshavephotos = (from t in photos select t.Event).Distinct(); //Ищем события только с фото, для списка фотоальбомов
            List <EventModelView> eventviews = new List<EventModelView>();
            foreach (EventModel e in eventshavephotos)
            {
                EventModelView emv = new EventModelView();
                emv.ЕventModel = e;
                var eventphotos = (from photo in photos
                                   where photo.Event.EventModelID == e.EventModelID
                                   select photo);
                emv.SmallSourse = eventphotos.First().SmallSourse; //Первое фото для картинки фотоальбома
                eventviews.Add(emv);
            }
            return View(eventviews.ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.ClubID = new SelectList(db.Clubs, "ClubID", "Title");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Title");
            return View();
        }

        // POST: Events/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventModelID,Title,Discription,Place,Fornewbies,DateTime,ClubID,TypeID")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(eventModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubID = new SelectList(db.Clubs, "ClubID", "Title", eventModel.ClubID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Title", eventModel.TypeID);
            return View(eventModel);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ClubID", "Title", eventModel.ClubID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Title", eventModel.TypeID);
            return View(eventModel);
        }

        // POST: Events/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventModelID,Title,Discription,Place,Fornewbies,DateTime,ClubID,TypeID")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ClubID", "Title", eventModel.ClubID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Title", eventModel.TypeID);
            return View(eventModel);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel eventModel = db.Events.Find(id);
            db.Events.Remove(eventModel);
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
