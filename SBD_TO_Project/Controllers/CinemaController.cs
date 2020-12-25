using Microsoft.AspNetCore.Mvc;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CinemaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Cinema> objList = _db.Cinema;
            return View(objList);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return NotFound();
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //Create Get
        public IActionResult Create()
        {
            return View();
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema obj)
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
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema obj)
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

            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }


        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.Cinema.Find(id);
            if (obj == null)
                return NotFound();

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
