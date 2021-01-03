using Microsoft.AspNetCore.Mvc;
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
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ScheduleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id)
        {
            List<Schedule> schedules = _db.Schedule.Where(s => s.IdCinema == Id).Include(se => se.ScheduleEntries).OrderBy(s => s.Date).ToList();
            if (schedules.Count == 0)
                schedules.Add(new Schedule() { IdCinema = Id});
            return View(schedules);
        }

        public IActionResult IndexBrowse(int id)
        {
            int weekDay = (int)DateTime.Today.DayOfWeek;
            if (weekDay == 0)
                weekDay = 7;

            DateTime beginDate = DateTime.Today.AddDays(-(weekDay - 1));
            DateTime endDate = DateTime.Today.AddDays(( 7 - weekDay));
            endDate += new TimeSpan(23, 59, 59);

            List<Schedule> schedules = _db.Schedule.Where(s => s.IdCinema == id && s.Date <= endDate && s.Date >= beginDate).OrderBy(s => s.Date)
                .Include(c => c.Cinema).Include(se => se.ScheduleEntries).ThenInclude(sr => sr.ScreeningRoom).ThenInclude( s => s.Seats)
                .Include(se => se.ScheduleEntries).ThenInclude(m => m.Movie).Include(se => se.ScheduleEntries).ThenInclude(r => r.Reservations).ToList();

            if(schedules.Count == 0)
            {
                schedules.Add(new Schedule()
                {
                    Cinema = _db.Cinema.Find(id)
                });
            }
            return View(schedules);
        }

        public IActionResult Create(int Id)
        {
            Schedule schedule = new Schedule() { IdCinema = Id, Date = DateTime.Now};
            return View(schedule);
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Schedule obj)
        {
            obj.Id = 0;
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = obj.IdCinema});
            }
            return View(obj);
        }

        public IActionResult Edit(int Id)
        {
            Schedule schedule = _db.Schedule.Include(se => se.ScheduleEntries).FirstOrDefault(s => s.Id == Id);
            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Schedule obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = obj.IdCinema});
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Schedule.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.Schedule.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdCinema});
        }
    }
}
