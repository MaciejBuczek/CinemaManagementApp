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
        
        public int? IdMovie { get; set; }
        [ForeignKey("IdMovie")]
        public virtual Movie Movie { get; set; }
        
        public int? IdGenre { get; set; }
        [ForeignKey("IdGenre")]
        public virtual Genre Genre { get; set; }
    }
}
