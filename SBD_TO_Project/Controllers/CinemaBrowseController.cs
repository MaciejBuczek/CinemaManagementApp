using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class CinemaBrowseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CinemaBrowseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            CinemaBrowseVM cinemaBrowseVM = new CinemaBrowseVM()
            {
                Cinemas = _db.Cinema.ToList(),
                Cities = _db.Cinema.Select(c => c.Town).Distinct().ToList()
            };
            return View(cinemaBrowseVM);
        }

        public IActionResult CheckInCinema(int id)
        {
            List<int> validIds = _db.ScheduleEntry.Where(se => se.IdMovie == id).Include(s => s.Schedule).Select(se => se.Schedule.IdCinema).ToList();
            CinemaBrowseVM cinemaBrowseVM = new CinemaBrowseVM()
            {
                Cinemas = _db.Cinema.Where(c => validIds.Contains(c.Id)).ToList(),
                Cities = _db.Cinema.Where(c => validIds.Contains(c.Id)).Select(c => c.Town).ToList()
            };
            return View("Index", cinemaBrowseVM);
        }
    }
}
