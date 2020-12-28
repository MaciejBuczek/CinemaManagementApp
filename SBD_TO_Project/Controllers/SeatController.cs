﻿using Microsoft.AspNetCore.Hosting;
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
            /*ScreeningRoom screeningRoom = _db.ScreeningRoom.Find(Id);
            List<List<SeatCheckBox>> seatCheckBoxeList = new List<List<SeatCheckBox>>();
            for (int i = 0; i < screeningRoom.NumberOfRows; i++)
            {
                List<SeatCheckBox> tempList = new List<SeatCheckBox>();
                for (int j = 0; j < screeningRoom.NumberOfSeatsPerRow; j++)
                {
                    tempList.Add(new SeatCheckBox()
                    {
                        RowNumber = i,
                        SeatNumber = j,
                        ScreeningRoomId = Id,
                        IsChecked = true
                    });
                }
                seatCheckBoxeList.Add(tempList);
            }

            SeatVM obj = new SeatVM() { IdCinema = screeningRoom.IdCinema, Seats = seatCheckBoxeList };*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeatVM seatVM)
        { 
            return RedirectToAction("Index", "ScreeningRoom", new { id = seatVM.IdCinema });
        }
    }
}
