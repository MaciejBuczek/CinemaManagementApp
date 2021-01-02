using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBD_TO_Project.Data;
using SBD_TO_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objList = _db.Employee.Where(e => e.IdManager == _userManager.GetUserId(User));
            return View(objList);
        }

        public IActionResult Edit(string id)
        {
            var obj = _db.Employee.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Edut Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                obj.UserName = obj.Email;
                obj.NormalizedUserName = obj.UserName.ToUpper();
                obj.NormalizedEmail = obj.Email.ToUpper();
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(string id)
        {
            var obj = _db.Employee.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult DeleteConfirm(string id)
        {
            var obj = _db.Employee.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            IEnumerable<CinemaEmployee> objList = _db.CinemaEmployee.Where(ce => ce.IdEmployee == id);
            foreach (var ce in objList)
                _db.Remove(ce);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
