using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class ActorMovie
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Actor")]
        public int IdActor { get; set; }
        [ForeignKey("Movie")]
        public int IdMovie { get; set; }
    }
}
