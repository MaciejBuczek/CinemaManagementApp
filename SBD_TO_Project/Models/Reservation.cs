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
        
        public string IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }
        
        public int IdSeat { get; set; }
        [ForeignKey("IdSeat")]
        public virtual Seat Seat { get; set; }
        
        public int IdScheduleEntry { get; set; }
        [ForeignKey("IdScheduleEntry")]
        public virtual ScheduleEntry ScheduleEntry { get; set; }

        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
    }
}
