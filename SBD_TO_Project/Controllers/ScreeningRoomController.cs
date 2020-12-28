using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ScreeningRoomController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ScreeningRoomController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id)
        {
            ScreeningRoomVM obj = new ScreeningRoomVM() {
                IdCinema = Id,
                ScreeningRooms = _db.ScreeningRoom.Where(sc => sc.IdCinema == Id).Include(s => s.Seats).ToList()
            };
            return View(obj);
        }

        //Create Get
        public IActionResult Create(int Id)
        {
            ScreeningRoom obj = new ScreeningRoom() { IdCinema = Id };
            return View(obj);
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScreeningRoom obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = 0;
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Create", "Seat", new { Id = obj.Id });
            }
            return View(obj);
        }

        //Show Get
        public IActionResult Show(int Id)
        {
            var obj = _db.ScreeningRoom.Find(Id);
            if (obj == null)
                return NotFound();

            List<Seat> seats = _db.Seat.Where(s => s.IdScreeningRoom == obj.Id).ToList();
            List<List<Seat>> listOfSeats = new List<List<Seat>>();

            for (int i = 0; i < obj.NumberOfRows; i++)
            {
                List<Seat> tempList = new List<Seat>();
                for (int j = 0; j < obj.NumberOfSeatsPerRow; j++)
                {
                    tempList.Add(seats[j + i * obj.NumberOfSeatsPerRow]);
                }
                listOfSeats.Add(tempList);
            }

            SeatVM seatVM = new SeatVM() { IdCinema = (int)obj.IdCinema, Seats = listOfSeats };

            return View(seatVM);
        }

        //Edit Get
        public IActionResult Edit(int Id)
        {
            var obj = _db.ScreeningRoom.Find(Id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ScreeningRoom obj)
        {
            if (ModelState.IsValid)
            {
                var objFromDb = _db.ScreeningRoom.AsNoTracking().FirstOrDefault(m => m.Id == obj.Id);
                if (obj.NumberOfRows != objFromDb.NumberOfRows || obj.NumberOfSeatsPerRow != objFromDb.NumberOfSeatsPerRow)
                {
                    IEnumerable<Seat> seats = _db.Seat.Where(s => s.IdScreeningRoom == obj.Id).ToList();
                    foreach(var seat in seats)
                        _db.Remove(seat);
                    _db.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Create", "Seat", new { Id = obj.Id });
                }
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", new { Id = obj.IdCinema });
            }
            return View(obj);
        }

        //Delete Get
        public IActionResult Delete(int Id)
        {
            var obj = _db.ScreeningRoom.Find(Id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int Id)
        {
            var obj = _db.ScreeningRoom.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdCinema });
        }

    }
}
