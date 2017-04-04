﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class EventModel
    {
        [Key]
        public int EventModelID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }
        [Required]
        public string Place { get; set; }
        public bool Fornewbies { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Required]
        public virtual int ClubID { get; set; }
    
        public virtual Club Club { get; set; }
        [Required]
        public virtual int TypeID { get; set; }
        
        public virtual Type Type { get; set; }
        public virtual ICollection<PhotoModel> PhotoModels { get; set; }
    }

}