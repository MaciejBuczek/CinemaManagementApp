using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class CinemaEmployeeVM
    {
        public int IdCinema { get; set; }

        public List<CheckBoxItem> EmployeeCheckBoxList { get; set; }
    }
}
