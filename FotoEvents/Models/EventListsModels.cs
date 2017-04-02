using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class Club
    {
        [Key]
        public int ClubID { get; set; }
        [Required]
        public string Title { get; set; }
    }
    public class Type
    {
        [Key]
        public int TypeID { get; set; }
        [Required]
        public string Title { get; set; }
    }
}