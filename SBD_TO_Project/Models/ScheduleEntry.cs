using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class ScheduleEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public double Price { get; set; }

        public double? NewPrice { get; set; }

        [Display(Name = "Movie")]
        public int IdMovie { get; set; }
        [ForeignKey("IdMovie")]
        public virtual Movie Movie { get; set; }
        
        public int IdSchedule { get; set; }
        [ForeignKey("IdSchedule")]
        public virtual Schedule Schedule { get; set; }

        [Display(Name = "Screening Room")]
        public int? IdScreeningRoom { get; set; }
        [ForeignKey("IdScreeningRoom")]
        public virtual ScreeningRoom ScreeningRoom { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
