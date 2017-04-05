using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name = "Мероприятие")]
        [DefaultValue("Введите название мероприятия")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Описание мероприятия")]
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }
        [Required]
        [Display(Name = "Место проведения")]
        public string Place { get; set; }
        [Display(Name = "Для новичков")]
        public bool Fornewbies { get; set; }
        [Required]
        [Display(Name = "Дата и время")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Required]
        [Display(Name = "Клуб")]
        public virtual int ClubID { get; set; }
    
        public virtual Club Club { get; set; }
        [Required]
        [Display(Name = "Тип мероприятия")]
        public virtual int TypeID { get; set; }
        
        public virtual Type Type { get; set; }
        public virtual ICollection<PhotoModel> PhotoModels { get; set; }
    }

}