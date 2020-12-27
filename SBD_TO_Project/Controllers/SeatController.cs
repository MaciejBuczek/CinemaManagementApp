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
            SeatCheckBox[,] seats = new SeatCheckBox[screeningRoom.NumberOfRows, screeningRoom.NumberOfSeatsPerRow];
            for (int i = 0; i < screeningRoom.NumberOfRows; i++)
                for (int j = 0; j < screeningRoom.NumberOfSeatsPerRow; j++)
                    seats[i, j] = new SeatCheckBox() { RowNumber = i, SeatNumber = j, ScreeningRoomId = Id, IsChecked = true };

            SeatVM obj = new SeatVM() { IdCinema = screeningRoom.IdCinema, Seats = seats };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeatVM seatVM)
        {
            for(int i = 0; i < seatVM.Seats.GetLength(0); i++)
                for(int j = 0; j < seatVM.Seats.GetLength(1); j++)
                    if (seatVM.Seats[i, j].IsChecked)
                    {
                        Seat seat = new Seat()
                        {
                            IdScreeningRoom = seatVM.Seats[i, j].ScreeningRoomId,
                            RowNumber = seatVM.Seats[i, j].RowNumber,
                            SeatNumber = seatVM.Seats[i, j].SeatNumber
                        };
                        _db.Add(seat);
                        _db.SaveChanges();
                    }
            return RedirectToAction("Index", "ScreeningRoom", new { id = seatVM.IdCinema });
        }
    }
}
