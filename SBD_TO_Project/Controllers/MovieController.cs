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
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> objList = _db.Movie.Include(d => d.Director).Include(ms => ms.MovieStudio);
            foreach(var obj in objList)
            {
                obj.MovieGenres = _db.MovieGenre.Where(u => u.IdMovie == obj.Id).ToList();
                obj.ActorMovies = _db.ActorMovie.Where(u => u.IdMovie == obj.Id).ToList();
            }
            return View(objList);
        }

        //Create get
        public IActionResult Create()
        {
            MovieVM movieVM = new MovieVM()
            {
                Movie = new Movie(),
                DirectorSelectList = _db.Director.Select(i => new SelectListItem
                {
                    Text = i.FirstName + " " + i.LastName,
                    Value = i.Id.ToString()

                }),
                MovieStudioSelectList = _db.MovieStudio.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Create post
        public IActionResult Create(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                string upload = webRootPath + WebConstants.ImageMoviePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                movieVM.Movie.Image = fileName + extension;

                _db.Movie.Add(movieVM.Movie);
                _db.SaveChanges();

                //return RedirectToAction("Create","MovieGenre", new { id = movieVM.Movie.Id});
                return RedirectToAction("Index");

            }
            return View(movieVM);
        }

        //Create get
        public IActionResult Edit(int Id)
        {
            MovieVM movieVM = new MovieVM()
            {
                Movie = _db.Movie.Find(Id),
                DirectorSelectList = _db.Director.Select(i => new SelectListItem
                {
                    Text = i.FirstName + " " + i.LastName,
                    Value = i.Id.ToString()

                }),
                MovieStudioSelectList = _db.MovieStudio.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (movieVM.Movie == null)
                return NotFound();
            else
                return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Create post
        public IActionResult Edit(MovieVM movieVM)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            var objFromDb = _db.Movie.AsNoTracking().FirstOrDefault(m => m.Id == movieVM.Movie.Id);
            if(files.Count > 0)
            {
                string upload = webRootPath + WebConstants.ImageMoviePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                var oldFile = Path.Combine(upload, objFromDb.Image);

                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                movieVM.Movie.Image = fileName + extension;
            }
            else
            {
                movieVM.Movie.Image = objFromDb.Image;
            }
            _db.Movie.Update(movieVM.Movie);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //delete get
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Movie movie = _db.Movie.Find(Id);
            movie.Director = _db.Director.Find(movie.IdDirector);
            movie.MovieStudio = _db.MovieStudio.Find(movie.IdMovieStudio);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Movie.Find(id);
            if (obj == null)
                return NotFound();

            string upload = _webHostEnvironment.WebRootPath + WebConstants.ImageMoviePath;

            var oldFile = Path.Combine(upload, obj.Image);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            _db.Movie.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
