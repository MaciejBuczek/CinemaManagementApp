using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> GenreSelectList { get; set; }
        public IEnumerable<SelectListItem> ActorSelectList { get; set; }
        public IEnumerable<SelectListItem> DirectorSelectList { get; set; }
    }
}
