using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class IndexMoviesVM
    {
        public List<Movie> RecommendedMovies { get; set; }
        public List<Movie> NewestMovies { get; set; }
    }
}
