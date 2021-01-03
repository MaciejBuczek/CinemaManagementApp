using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class ReservationVM
    {
        public ScheduleEntry ScheduleEntry { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<SelectListItem> PaymentSelectList { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
