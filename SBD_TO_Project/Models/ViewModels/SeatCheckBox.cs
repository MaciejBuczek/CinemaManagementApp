using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class SeatCheckBox
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public int ScreeningRoomId { get; set; }
        public bool IsChecked { get; set; }
    }
}
