using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    [Table("MovieStudio")]
    public class MovieStudio : Address
    {
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Established date")]
        public DateTime EstablishedDate { get; set; }
    }
}
