using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        [Required]
        public string Status { get; set; }
        
        public int IdPayment { get; set; }
        [ForeignKey("IdPayment")]
        public virtual Payment Payment { get; set; }

        public virtual ICollection<Reservation> ScheduleEntries { get; set; }
    }
}
