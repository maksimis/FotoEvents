using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    
    public class EventModelView 
   {
     [NotMapped]
      public EventModel ЕventModel { get; set; }
     [NotMapped]
     [DataType(DataType.ImageUrl)]
     public string SmallSourse { get; set; }

    }
}