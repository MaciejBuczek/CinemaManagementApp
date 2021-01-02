using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Comment> objList = _db.Comment.Where(c => c.IsConfirmed == false).Include(m => m.Movie).Include(c => c.Customer).OrderBy(c => c.IdMovie);
            return View(objList);
        }

        //Delete Get
        public IActionResult Delete(int id)
        {
            var obj = _db.Comment.Where(c => c.Id == id).Include(m => m.Movie).Include(c => c.Customer).FirstOrDefault();
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = _db.Comment.Find(id);
            if (obj == null)
                return NotFound();

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Accept Get
        public IActionResult Accept(int id)
        {
            var obj = _db.Comment.Where(c => c.Id == id).Include(m => m.Movie).Include(c => c.Customer).FirstOrDefault();
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptConfirm(int id)
        {
            var obj = _db.Comment.Find(id);
            if (obj == null)
                return NotFound();

            obj.IsConfirmed = true;
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
