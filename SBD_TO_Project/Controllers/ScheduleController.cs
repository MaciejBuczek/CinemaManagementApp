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
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ScheduleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id)
        {
            List<Schedule> schedules = _db.Schedule.Where(s => s.IdCinema == Id).Include(se => se.ScheduleEntries).ToList();
            if (schedules.Count == 0)
                schedules.Add(new Schedule() { IdCinema = Id});
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
