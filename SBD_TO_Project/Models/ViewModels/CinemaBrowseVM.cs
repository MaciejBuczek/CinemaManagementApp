using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class CinemaBrowseVM
    {
        public IEnumerable<Cinema> Cinemas { get; set; }
        public IEnumerable<string> Cities { get; set; }
    }
}
