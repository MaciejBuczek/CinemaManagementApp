using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> objList = _db.Movie;
            foreach(var obj in objList)
            {
                obj.Director = _db.Director.FirstOrDefault(u => u.Id == obj.IdDirector);
                obj.MovieStudio = _db.MovieStudo.FirstOrDefault(u => u.Id == obj.IdMovieStudio);
            }
            return View(objList);
        }

        //Upsert Get
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> DirectorDropDown = _db.Director.Select(i => new SelectListItem
            {
                Text = _db.Person.FirstOrDefault(u => u.Id == i.IdPerson).FirstName + " " + _db.Person.FirstOrDefault(u => u.Id == i.IdPerson).LastName
            });;


            ViewBag.DirectorDropDown = DirectorDropDown;

            Movie movie = new Movie();
            if(id == null)
            {
                return View(movie);
            }
            else
            {
                movie = _db.Movie.Find(id);
                if(movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }
        }

        //Upsert Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete Get
        public IActionResult Delete(int id)
        {
            var obj = _db.Genre.Find(id);
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
            var obj = _db.Genre.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
