using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}