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
    public  class AddataController : Controller
    {
        private EventContext context = new EventContext();
        public ActionResult Addata()
        {
           if (context.Types.Count()==0) { 
            var type1 = new Models.Type { Title = "Балаган" };
            var type2 = new Models.Type { Title = "Тусовка" };
            var type3 = new Models.Type { Title = "Прогулка" };
            var type4 = new Models.Type { Title = "Вечеринка" };
            context.Types.Add(type1);
            context.Types.Add(type2);
            context.Types.Add(type3);
            context.Types.Add(type4);
            context.SaveChanges();
            }
            if (context.Clubs.Count() == 0)
            {
                var club1 = new Models.Club { Title = "Клуб, просто клуб" };
                var club2 = new Models.Club { Title = "Свежий воздух" };
                var club3 = new Models.Club { Title = "Лес" };
                context.Clubs.Add(club1);
                context.Clubs.Add(club2);
                context.Clubs.Add(club3);
                context.SaveChanges();
            }
            for (int i = 1; i <= 10; i++)
            {
                var Event1 = new EventModel();
                Event1.Title = "Великолепная вечеринка" + i;
                Event1.Discription = "Описание великолепной вечеринки, достаточно длинное чтобы посмотреть что можно было бы рассказать о вечеринке";
                Event1.Place = "Где-то недалеко";
                Event1.Fornewbies = (i / 2 == 0);
                Event1.DateTime = DateTime.Now.AddDays(i);
                Event1.ClubID = 2;
                Event1.TypeID = 1;
                context.Events.Add(Event1);
            }
            context.SaveChanges();
            foreach (EventModel ev in context.Events)
            { 
                for (int i = 1; i <= 10; i++)
                {
                    var photo = new PhotoModel();
                    photo.LargeSourse = @"Images\large\" + i + ".jpg";
                    photo.SmallSourse = @"Images\small\" + i + ".jpg";
                    photo.DateUploaded = DateTime.Now;
                    photo.Event = ev;
                    photo.Event.EventModelID = ev.EventModelID;
                    context.Photos.Add(photo);
                }
                
            }
            context.SaveChanges();

            return RedirectToAction("Index","Events");


        }
    
    
    }
}