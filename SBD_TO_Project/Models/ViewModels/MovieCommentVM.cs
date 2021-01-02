using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class MovieCommentVM
    {
        public Movie Movie { get; set; }
        public Comment Comment { get; set; }
        public string IdCustomer { get; set; }
    }
}
