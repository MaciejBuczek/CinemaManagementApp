using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class MovieBrowseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public MovieBrowseController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
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

        public IActionResult Details(int Id)
        {
            MovieCommentVM movieCommentVM = new MovieCommentVM()
            {
                Movie = _db.Movie.Where(m => m.Id == Id).Include(mg => mg.MovieGenres).ThenInclude(g => g.Genre).Include(am => am.ActorMovies).ThenInclude(a => a.Actor)
                .Include(d => d.Director).Include(ms => ms.MovieStudio).Include(c => c.Comments).ThenInclude(c => c.Customer).FirstOrDefault(),
                IdCustomer = _userManager.GetUserId(User)
            };
            if (User.Identity.IsAuthenticated)
                movieCommentVM.Comment = new Comment() { IdMovie = Id, IdCustomer = _userManager.GetUserId(User) };
            return View(movieCommentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Create post
        public IActionResult Create(MovieCommentVM movieCommentVM)
        {
            movieCommentVM.Comment.Date = DateTime.Now;
            movieCommentVM.Comment.IsConfirmed = false;
            movieCommentVM.Movie = _db.Movie.Where(m => m.Id == movieCommentVM.Comment.IdMovie).Include(mg => mg.MovieGenres).ThenInclude(g => g.Genre).Include(am => am.ActorMovies).ThenInclude(a => a.Actor)
                .Include(d => d.Director).Include(ms => ms.MovieStudio).Include(c => c.Comments).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _db.Comment.Add(movieCommentVM.Comment);
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = movieCommentVM.Comment.IdMovie });
        }
    }
}