using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class ScheduleEntryVM
    {
        public ScheduleEntry ScheduleEntry { get; set; }
        public IEnumerable<SelectListItem> Movies { get; set; }
        public IEnumerable<SelectListItem> ScreeningRooms { get; set; }
    }
}
