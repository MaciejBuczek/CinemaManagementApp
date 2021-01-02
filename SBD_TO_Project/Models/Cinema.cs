using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    [Table("Cinema")]
    public class Cinema : Address
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name="Opened at")]
        public DateTime OpenTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Closed at")]
        public DateTime CloseTime { get; set; }
        //public virtual ICollection<CinemaEmployee> CinemaEmployees { get; set; }
    }
}
