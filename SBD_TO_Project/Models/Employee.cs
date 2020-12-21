using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; }
        public float Salary { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start date of work")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End date of work")]
        public DateTime? EndDate { get; set; }
        public int? IdManager { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
