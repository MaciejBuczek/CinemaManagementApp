using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ComplaintController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Complaint> objList = null;
            if (User.IsInRole(WebConstants.CustomerRole))
            {
                objList = _db.Complaint.Include(c => c.Order).ThenInclude(o => o.Reservations)
                    .Where(c => c.Order.Reservations.All(r => r.IdCustomer == _userManager.GetUserId(User)));
            }
            else if (User.IsInRole(WebConstants.EmployeeRole) || User.IsInRole(WebConstants.ManagerRole))
            {
                List<int> cinemasIds = _db.CinemaEmployee.Where(ce => ce.IdEmployee == _userManager.GetUserId(User)).Select(ce => ce.IdCinema).Distinct().ToList();
                objList = _db.Complaint.Include(c => c.Order).ThenInclude(o => o.Reservations).ThenInclude(r => r.Customer)
                    .Include(c => c.Order).ThenInclude(o => o.Reservations).ThenInclude(r => r.ScheduleEntry).ThenInclude(se => se.Schedule)
                    .Where(c => c.Outcome == WebConstants.ComplaintOutcome.Pending.ToString() && c.Order.Reservations.All(r => cinemasIds.Contains(r.ScheduleEntry.Schedule.IdCinema)));
            }
            else
            {
                objList = _db.Complaint.Include(c => c.Order).ThenInclude(o => o.Reservations).ThenInclude(r => r.Customer)
                    .Where(c => c.Outcome == WebConstants.ComplaintOutcome.Pending.ToString());
            }
            return View(objList);
        }
        public IActionResult Create(int id)
        {
            Complaint obj = new Complaint()
            {
                IdOrder = id
            };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint obj)
        {
            obj.Id = 0;
            obj.Outcome = WebConstants.ComplaintOutcome.Pending.ToString();
            obj.IdCustomer = _userManager.GetUserId(User);
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Positive(int id)
        {
            var obj = _db.Complaint.Find(id);
            obj.Outcome = WebConstants.ComplaintOutcome.Positive.ToString();
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Negative(int id)
        {
            var obj = _db.Complaint.Find(id);
            obj.Outcome = WebConstants.ComplaintOutcome.Negative.ToString();
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
