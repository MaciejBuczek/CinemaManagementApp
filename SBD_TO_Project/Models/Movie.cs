using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Age rating")]
        public int? AgeRating { get; set; }

        public int? IdDirector { get; set; }
        [ForeignKey("IdDirector")]
        public virtual Director Director { get; set; }

        public int? IdMovieStudio { get; set; }
        [ForeignKey("IdMovieStudio")]
        public virtual MovieStudio MovieStudio { get; set; }
    }
}
