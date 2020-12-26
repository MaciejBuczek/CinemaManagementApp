using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class MovieGenreVM
    {
        public int IdMovie { get; set; }

        public List<CheckBoxItem> GenreCheckBoxList { get; set; }
    }
}
