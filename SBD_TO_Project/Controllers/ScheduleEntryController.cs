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
    public class ScheduleEntryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ScheduleEntryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int Id)
        {
            List<ScheduleEntry> objList = _db.ScheduleEntry.Where(se => se.IdSchedule == Id).Include(m => m.Movie).Include(sr => sr.ScreeningRoom).
                Include(s => s.Schedule). OrderBy(se => se.IdScreeningRoom).OrderBy(se => se.StartTime).ToList();
            if(objList.Count == 0)
            {
                Schedule schedule = _db.Schedule.Find(Id);
                objList.Add(new ScheduleEntry() { IdSchedule = schedule.Id, Schedule = schedule });
            }
            return View(objList);
        }

        public IActionResult AddPromotion(int Id)
        {
            ScheduleEntry obj = _db.ScheduleEntry.Find(Id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPromotion(ScheduleEntry obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = obj.IdSchedule });
            }
            return View(obj);
        }

        public IActionResult RemovePromotion(int Id)
        {
            ScheduleEntry obj = _db.ScheduleEntry.Find(Id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePromotionPost(int id)
        {
            var obj = _db.ScheduleEntry.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.NewPrice = null;
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdSchedule });
        }

        public IActionResult Create(int Id)
        {
            Schedule schedule = _db.Schedule.Find(Id);           
            ScheduleEntryVM obj = new ScheduleEntryVM()
            {
                ScheduleEntry = new ScheduleEntry() { IdSchedule = Id },
                Movies = _db.Movie.Select(m => new SelectListItem
                {
                    Text = m.Title,
                    Value = m.Id.ToString()

                }),
                ScreeningRooms = _db.ScreeningRoom.Where(sr => sr.IdCinema == schedule.IdCinema ).Select(sr => new SelectListItem
                {
                    Text = sr.ScreeningRoomNumber.ToString(),
                    Value = sr.Id.ToString()

                })
            };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScheduleEntryVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj.ScheduleEntry);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = obj.ScheduleEntry.IdSchedule});
            }
            return View(obj);
        }

        public IActionResult Edit(int Id)
        {
            ScheduleEntry scheduleEntry = _db.ScheduleEntry.Find(Id);
            Schedule schedule = _db.Schedule.Find(scheduleEntry.IdSchedule);
            ScheduleEntryVM obj = new ScheduleEntryVM()
            {
                ScheduleEntry = scheduleEntry,
                Movies = _db.Movie.Select(m => new SelectListItem
                {
                    Text = m.Title,
                    Value = m.Id.ToString()

                }),
                ScreeningRooms = _db.ScreeningRoom.Where(sr => sr.IdCinema == schedule.IdCinema).Select(sr => new SelectListItem
                {
                    Text = sr.ScreeningRoomNumber.ToString(),
                    Value = sr.Id.ToString()

                })
            };
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ScheduleEntryVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj.ScheduleEntry);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = obj.ScheduleEntry.IdSchedule });
            }
            return View(obj);
        }

        public IActionResult Delete(int Id)
        {
            ScheduleEntry obj = _db.ScheduleEntry.Include(m => m.Movie).Include(sr => sr.ScreeningRoom).FirstOrDefault(se => se.Id == Id);
            if(obj == null)
            {
                return NotFound();
            }
 
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.ScheduleEntry.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdSchedule});
        }
    }
}
