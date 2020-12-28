using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class SeatVM
    {
        public int IdCinema { get; set; }

        public List<List<Seat>> Seats { get; set; }
        //public SeatCheckBox[,] Seats { get; set; }
    }
}
