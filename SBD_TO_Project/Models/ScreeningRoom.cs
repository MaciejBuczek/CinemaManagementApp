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
        public int ScreeningRoomNumber { get; set; }
        [ForeignKey("Cinema")]
        public int IdCinema { get; set; }
    }
}
