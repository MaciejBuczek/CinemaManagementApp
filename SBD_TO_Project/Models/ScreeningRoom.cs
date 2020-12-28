using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class ScreeningRoom
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Screening Room Number")]
        [Required]
        public String ScreeningRoomNumber { get; set; }
        [Display(Name = "Number of rows")]
        public int NumberOfRows { get; set; }
        [Display(Name = "Number of seats per row")]
        public int NumberOfSeatsPerRow { get; set; }
        
        public int? IdCinema { get; set; }
        [ForeignKey("IdCinema")]
        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
