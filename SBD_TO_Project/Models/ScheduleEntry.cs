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
        public DateTime Time { get; set; }
        [ForeignKey("Movie")]
        public int IdMovie { get; set; }
        [ForeignKey("Schedule")]
        public int IdSchedule { get; set; }
        [ForeignKey("ScreeningRoom")]
        public int idScreeningRoom { get; set; }
    }
}
