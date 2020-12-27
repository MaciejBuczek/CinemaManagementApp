using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class ScreeningRoomVM
    {
        public int IdCinema { get; set; }
        public List<ScreeningRoom> screeningRooms { get; set; }
    }
}
