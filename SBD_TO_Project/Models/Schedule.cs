using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public int? IdCinema { get; set; }
        [ForeignKey("IdCinema")]
        public virtual Cinema Cinema { get; set; }
    }
}
