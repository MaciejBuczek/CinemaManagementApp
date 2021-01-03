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
    public class SeatController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SeatController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id)
        {
            List<Seat> objList = _db.Seat.Where(sr => sr.ScreeningRoom.Id == Id).ToList();
            return View(objList);
        }

        public IActionResult Create(int Id)
        {
            ScreeningRoom screeningRoom = _db.ScreeningRoom.Find(Id);
            List<List<Seat>> seats = new List<List<Seat>>();
            for (int i = 0; i < screeningRoom.NumberOfRows; i++)
            {
                List<Seat> tempList = new List<Seat>();
                for (int j = 0; j < screeningRoom.NumberOfSeatsPerRow; j++)
                {
                    tempList.Add(new Seat()
                    {
                        RowNumber = i,
                        SeatNumber = j,
                        IdScreeningRoom = Id,
                        IsValid = true
                    });
                }
                seats.Add(tempList);
            }

            SeatVM obj = new SeatVM() { IdCinema = (int)screeningRoom.IdCinema, Seats = seats };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeatVM seatVM)
        {
            foreach(var row in seatVM.Seats)
            {
                foreach(var seat in row)
                {
                    _db.Add(seat);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "ScreeningRoom", new { id = seatVM.IdCinema });
        }

        public IActionResult Edit(int Id)
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

        public IActionResult Choose(int id)
        {
            var scheduleEntry = _db.ScheduleEntry.Where(se => se.Id == id).Include(sr => sr.ScreeningRoom).FirstOrDefault();

            if (scheduleEntry == null)
                return NotFound();

            List<Seat> seats = _db.Seat.Where(s => s.IdScreeningRoom == scheduleEntry.ScreeningRoom.Id).ToList();
            List<List<CheckBoxItem>> seatCheckBoxList = new List<List<CheckBoxItem>>();

            for (int i = 0; i < scheduleEntry.ScreeningRoom.NumberOfRows; i++)
            {
                List<CheckBoxItem> tempList = new List<CheckBoxItem>();
                for (int j = 0; j < scheduleEntry.ScreeningRoom.NumberOfSeatsPerRow; j++)
                {
                    CheckBoxItem seatCheckBox = new CheckBoxItem()
                    {
                        Id = seats[j + i * scheduleEntry.ScreeningRoom.NumberOfSeatsPerRow].Id,
                        Object = seats[j + i * scheduleEntry.ScreeningRoom.NumberOfSeatsPerRow],
                        IsChecked = false
                    };
                    tempList.Add(seatCheckBox);
                }
                seatCheckBoxList.Add(tempList);
            }

            List<Seat> reservedSeat = _db.Reservation.Where(r => r.IdScheduleEntry == id).Include(s => s.Seat).Select(s => s.Seat).ToList();
            foreach(var seat in reservedSeat)
            {
                seatCheckBoxList[seat.RowNumber][seat.SeatNumber].IsChecked = true;
            }

            ChooseSeatVM chooseSeatVM = new ChooseSeatVM() { ScheduleEntryId = id, SeatCheckBoxList = seatCheckBoxList };

            return View(chooseSeatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SeatVM seatVM)
        {
            foreach (var row in seatVM.Seats)
            {
                foreach (var seat in row)
                {
                    _db.Update(seat);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "ScreeningRoom", new { id = seatVM.IdCinema });
        }

    }
}
