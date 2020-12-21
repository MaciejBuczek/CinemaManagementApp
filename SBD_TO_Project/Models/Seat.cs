using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Seat number")]
        public int SeatNumber { get; set; }
        [Display(Name = "Row number")]
        public int RowNumber { get; set; }
        
        public int? IdScreeningRoom { get; set; }
        [ForeignKey("IdScreeningRoom")]
        public virtual ScreeningRoom ScreeningRoom { get; set; }
    }
}
