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
        [ForeignKey("Reservation")]
        public int IdReservation { get; set; }
        [ForeignKey("Payment")]
        public int IdPayment { get; set; }
    }
}
