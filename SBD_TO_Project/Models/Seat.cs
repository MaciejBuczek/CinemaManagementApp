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
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        [ForeignKey("ScreeningRoom")]
        public int IdScreeningRoom { get; set; }
    }
}
