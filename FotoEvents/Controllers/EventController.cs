﻿using System;
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
    public class EventController : Controller
    {
        private EventContext db = new EventContext();

        // GET: EventModels
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            IEnumerable<EventModel> events = db.Events.OrderBy(x=> x.DateTime).ToList();
            IEnumerable<PhotoModel> photos = db.Photos.ToList();
            List<EventModelView> eventviews = new List<EventModelView>() ;
            foreach (EventModel e in events)
            {
                EventModelView emv = new EventModelView();
                emv.ЕventModel = e;

                emv.SmallSourse = (from photo in photos
                                  where photo.Event.EventModelID == e.EventModelID
                                  select photo).Random().SmallSourse;
                eventviews.Add(emv);
            }
            return View(eventviews.ToPagedList(pageNumber, pageSize));
           // return View(db.Events.ToList());
        }

        // GET: EventModels/Details/5
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

        // GET: EventModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventModelID,Title,Discription,Place,Fornewbies,DateTime")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(eventModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventModel);
        }

        // GET: EventModels/Edit/5
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
            ClubsDropDownList(eventModel.Club.ClubID);
            TypesDropDownList(eventModel.Type.TypeID);
            return View(eventModel);
        }

        // POST: EventModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventModelID,Title,Discription,Place,Fornewbies,DateTime")] EventModel eventModel)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(eventModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventModel);
        }

        // GET: EventModels/Delete/5
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

        // POST: EventModels/Delete/5
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
        private void ClubsDropDownList(object selectedClub = null)
        {
            var ClubQuery = (from d in db.Clubs
                                    orderby d.ClubID
                                    select d).ToList<Club>();
            ClubQuery.Add(new Club { ClubID = 0, Title = "Выберите клуб" });

            ViewBag.ClubID = new SelectList(ClubQuery, "ClubID", "Title", selectedClub);

        }
        private void TypesDropDownList(object selectedType = null)
        {
            var TypeQuery = (from d in db.Types
                             orderby d.TypeID
                             select d).ToList<Models.Type>();
            TypeQuery.Add(new Models.Type { TypeID = 0, Title = "Выберите тип" });

            ViewBag.TypeID = new SelectList(TypeQuery, "TypeID", "Title", selectedType);

        }
    }
}
