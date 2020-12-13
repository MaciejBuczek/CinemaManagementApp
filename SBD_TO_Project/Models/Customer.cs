using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public bool IsRegularCustomer { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
    }
}
