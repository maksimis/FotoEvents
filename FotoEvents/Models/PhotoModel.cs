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
        public string LargeSourse { get; set; }
        public string SmallSourse { get; set; }
        
    }
}