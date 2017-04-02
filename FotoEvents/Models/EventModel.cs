using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class EventModel
    {
        public int EventModelID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Place { get; set; }
        public bool Fornewbies { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Club Club { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<PhotoModel> PhotoModels { get; set; }
    }
}