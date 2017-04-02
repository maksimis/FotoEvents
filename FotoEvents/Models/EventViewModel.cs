using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class EventModelView : EventModel
    {
        public EventModel ЕventModel { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SmallSourse { get; set; }

    }
}