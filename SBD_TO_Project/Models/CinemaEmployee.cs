using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class CinemaEmployee
    {
        [Key]
        public int Id { get; set; }
        
        public int? IdCinema { get; set; }
        [ForeignKey("IdCinema")]
        public virtual Cinema Cinema { get; set; }
        
        public int? IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public virtual Employee Employee { get; set; }
    }
}
