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
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public CinemaController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Cinema> objList;
            if (User.IsInRole(WebConstants.AdminRole))
                objList = _db.Cinema;
            else
                objList = _db.CinemaEmployee.Where(ce => ce.IdEmployee == _userManager.GetUserId(User)).Include(c => c.Cinema).Select(c => c.Cinema);
            return View(objList);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return NotFound();
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //Create Get
        public IActionResult Create()
        {
            return View();
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();

                if(User.IsInRole(WebConstants.ManagerRole))
                {
                    _db.Add(new CinemaEmployee() { IdCinema = obj.Id, IdEmployee = _userManager.GetUserId(User) });
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit get
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete get
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();

            IEnumerable<ScreeningRoom> screeningRooms = _db.ScreeningRoom.Where(sc => sc.IdCinema == id);
            IEnumerable<Schedule> schedules = _db.Schedule.Where(sc => sc.IdCinema == id);
            foreach(var sc in screeningRooms)
            {
                _db.Remove(sc);
                _db.SaveChanges();
            }
            foreach (var s in schedules)
            {
                _db.Remove(s);
                _db.SaveChanges();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
