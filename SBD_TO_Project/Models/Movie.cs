using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? AgeRating { get; set; }
        [ForeignKey("Director")]
        public int IdDirector { get; set; }
        [ForeignKey("MovieStudio")]
        public int IdMovieStudio { get; set; }
    }
}
