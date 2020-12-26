using Microsoft.AspNetCore.Mvc;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using SBD_TO_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ActorMovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ActorMovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int Id)
        {
            List<ActorMovie> objList = _db.ActorMovie.Where(am => am.IdMovie == Id).ToList();
            foreach (var obj in objList)
            {
                obj.Actor = _db.Actor.FirstOrDefault(a => a.Id == obj.IdActor);
            }
            if(objList.Count == 0)
            {
                objList.Add(new ActorMovie
                {
                    IdMovie = Id
                });
            }
            return View(objList);
        }
        public IActionResult Create(int Id)
        {
            var existingActorIds = _db.ActorMovie.Where(am => am.IdMovie == Id).Select(am => am.IdActor).ToArray();

            MovieActorVM movieActorVM = new MovieActorVM()
            {
                IdMovie = Id,
                ActorCheckBoxList = _db.Actor.Where(a => !existingActorIds.Contains(a.Id)).Select(a => new CheckBoxItem
                {
                    Id = a.Id,
                    Object = a,
                    IsChecked = false
                }).ToList()
            };
            return View(movieActorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieActorVM movieActorVM)
        {
            foreach (var obj in movieActorVM.ActorCheckBoxList)
            {
                if (obj.IsChecked)
                {
                    ActorMovie actorMovie = new ActorMovie()
                    {
                        IdMovie = movieActorVM.IdMovie,
                        IdActor = obj.Id
                    };
                    _db.Add(actorMovie);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id = movieActorVM.IdMovie });
        }

        //Delete Get
        public IActionResult Delete(int id)
        {
            var obj = _db.ActorMovie.Find(id);
            obj.Movie = _db.Movie.Find(obj.IdMovie);
            obj.Actor = _db.Actor.Find(obj.IdActor);
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
            var obj = _db.ActorMovie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdMovie });
        }
    }
}
