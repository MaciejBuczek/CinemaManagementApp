using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Payment Method")]
        public string Type { get; set; }
    }
}
