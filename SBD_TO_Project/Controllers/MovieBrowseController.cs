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
    public class MovieBrowseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieBrowseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            MovieBrowseVM movieBrowseVM = new MovieBrowseVM()
            {
                Movies = _db.Movie.Include(mg => mg.MovieGenres).ThenInclude(g => g.Genre).Include(am => am.ActorMovies).ThenInclude(a => a.Actor)
                .Include(d => d.Director).Include(ms => ms.MovieStudio),
                Genres = _db.Genre
            };
            return View(movieBrowseVM);
        }
    }
}