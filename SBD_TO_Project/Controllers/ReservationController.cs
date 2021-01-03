using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChooseSeatVM chooseSeatVM)
        {
            List<Seat> seats = new List<Seat>();
            foreach (var row in chooseSeatVM.SeatCheckBoxList)
            {
                foreach(var seat in row)
                {
                    if (seat.IsChecked)
                        seats.Add(_db.Seat.Find(seat.Id));
                }
            }

            ScheduleEntry scheduleEntry = _db.ScheduleEntry.Where(se => se.Id == chooseSeatVM.ScheduleEntryId).Include(m => m.Movie).
                Include(s => s.Schedule).ThenInclude(c => c.Cinema).FirstOrDefault();

            ReservationVM reservationVM = new ReservationVM()
            {
                ScheduleEntry = scheduleEntry,
                Customer = _db.Customer.Find(_userManager.GetUserId(User)),
                Payment = new Payment(),
                Order = new Order()
                {
                    Price = (float)(seats.Count * scheduleEntry.Price)
                },
                PaymentSelectList = ((IEnumerable<WebConstants.PaymentMethod>)Enum.GetValues(typeof(WebConstants.PaymentMethod))).Select(pm => new SelectListItem { 
                    Text = pm.ToString().Replace('_', ' '),
                    Value = pm.ToString()
                }),
                Seats = seats
            };
            return View(reservationVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirm(ReservationVM reservationVM)
        {
            _db.Add(reservationVM.Payment);
            _db.SaveChanges();

            reservationVM.Order.Date = DateTime.Now;
            reservationVM.Order.Status = (reservationVM.Payment.Type != WebConstants.PaymentMethod.Cash.ToString()) ? WebConstants.OrderStatus.Paid.ToString()
                    : WebConstants.OrderStatus.Not_Paid.ToString();
            reservationVM.Order.IdPayment = reservationVM.Payment.Id;
            _db.Add(reservationVM.Order);
            _db.SaveChanges();

            foreach(var seat in reservationVM.Seats)
            {
                Reservation reservation = new Reservation()
                {
                    IdCustomer = reservationVM.Customer.Id,
                    IdSeat = seat.Id,
                    IdScheduleEntry = reservationVM.ScheduleEntry.Id,
                    IdOrder = reservationVM.Order.Id
                };
                _db.Add(reservation);
                _db.SaveChanges();
            }
            return View();
        }
    }
}
