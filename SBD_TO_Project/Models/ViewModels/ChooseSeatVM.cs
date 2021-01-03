using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class ChooseSeatVM
    {
        public int ScheduleEntryId { get; set; }
        public List<List<CheckBoxItem>> SeatCheckBoxList { get; set; }
    }
}
