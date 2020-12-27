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
            List<ScreeningRoom> screeningRooms = _db.ScreeningRoom.Where(c => c.Cinema.Id == Id).ToList();
            ScreeningRoomVM obj = new ScreeningRoomVM() {IdCinema = Id, screeningRooms = screeningRooms };
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

    }
}
