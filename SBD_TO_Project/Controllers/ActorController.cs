using Microsoft.AspNetCore.Mvc;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Actor> objList = _db.Actor;
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
        public IActionResult Create(Actor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit Get
        public IActionResult Edit(int id)
        {
            var obj = _db.Actor.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Actor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete Get
        public IActionResult Delete(int id)
        {
            var obj = _db.Actor.Find(id);
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
            var obj = _db.Actor.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
