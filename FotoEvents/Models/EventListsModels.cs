using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        public string Title { get; set; }
    }
    public class Type
    {
        public int TypeID { get; set; }
        public string Title { get; set; }
    }
}