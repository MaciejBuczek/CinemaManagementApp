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
        public DateTime OpenTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime CloseTime { get; set; }
        //public virtual ICollection<CinemaEmployee> CinemaEmployees { get; set; }
    }
}
