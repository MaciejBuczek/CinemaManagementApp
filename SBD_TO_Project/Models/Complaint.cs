using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string ComplaintContent { get; set; }
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
    }
}
