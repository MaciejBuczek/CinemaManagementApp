using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class MovieGenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieGenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id)
        {
            List<MovieGenre> objList = _db.MovieGenre.Where(mg => mg.IdMovie == Id).ToList();
            foreach (var obj in objList)
            {
                obj.Genre = _db.Genre.FirstOrDefault(u => u.Id == obj.IdGenre);
            }
            if (objList.Count == 0)
            {
                objList.Add(new MovieGenre
                {
                    IdMovie = Id
                });
            }
            return View(objList);
        }

        public IActionResult Create(int Id)
        {
            var existingGenresIds = _db.MovieGenre.Where(mg => mg.IdMovie == Id).Select(mg => mg.IdGenre).ToArray();

            MovieGenreVM movieGenreVM = new MovieGenreVM()
            {
                IdMovie = Id,
                GenreCheckBoxList = _db.Genre.Where(g => !existingGenresIds.Contains(g.Id)).Select(g => new CheckBoxItem
                {
                    Id = g.Id,
                    Object = g,
                    IsChecked = false
                }).ToList()
            };
            return View(movieGenreVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieGenreVM movieGenreVM)
        {
            foreach(var obj in movieGenreVM.GenreCheckBoxList)
            {
                if (obj.IsChecked) {
                    MovieGenre movieGenre = new MovieGenre()
                    {
                        IdMovie = movieGenreVM.IdMovie,
                        IdGenre = obj.Id
                    };
                    _db.Add(movieGenre);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id = movieGenreVM.IdMovie});
        }

        //Delete Get
        public IActionResult Delete(int id)
        {
            var obj = _db.MovieGenre.Find(id);
            obj.Movie = _db.Movie.Find(obj.IdMovie);
            obj.Genre = _db.Genre.Find(obj.IdGenre);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.MovieGenre.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdMovie});
        }
    }
}
