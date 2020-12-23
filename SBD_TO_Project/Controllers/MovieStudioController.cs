using Microsoft.AspNetCore.Mvc;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class MovieStudioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieStudioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieStudio> objList = _db.MovieStudo;
            return View(objList);
        }

        //Create Get
        public IActionResult Create()
        {
            return View();
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieStudio obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit get
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();
            var obj = _db.MovieStudo.Find(id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }


        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieStudio obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete get
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var obj = _db.MovieStudo.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }


        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.MovieStudo.Find(id);
            if (obj == null)
                return NotFound();

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
