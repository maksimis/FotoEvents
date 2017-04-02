using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class PhotoModel
    {
        [Key]
        public int PhotoModelID { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string LargeSourse { get; set; }
        [DataType(DataType.ImageUrl)]
        public string SmallSourse { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public DateTime DateUploaded { get; set; }
        public virtual EventModel Event { get; set; }

    }
}