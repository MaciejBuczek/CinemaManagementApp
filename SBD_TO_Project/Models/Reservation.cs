using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        [ForeignKey("Seat")]
        public int IdSeat { get; set; }
        [ForeignKey("ScheduleEntry")]
        public int IdScheduleEntry { get; set; }
    }
}
