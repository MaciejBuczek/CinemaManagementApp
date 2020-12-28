using Microsoft.AspNetCore.Mvc;
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
                Cinemas = _db.Cinema,
                Cities = _db.Cinema.Select(c => c.Town).Distinct()
            };
            return View(cinemaBrowseVM);
        }
    }
}
