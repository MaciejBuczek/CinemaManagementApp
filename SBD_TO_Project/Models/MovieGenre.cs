using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int IdMovie { get; set; }
        [ForeignKey("Genre")]
        public int IdGenre { get; set; }
    }
}
