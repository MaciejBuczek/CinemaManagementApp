using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class EmployeeCinemaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeCinemaController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            List<CinemaEmployee> objList = _db.CinemaEmployee.Where(ce => ce.IdCinema == id).Include(c => c.Cinema).Include(e => e.Employee).ToList();
            if (objList.Count == 0)
                objList.Add(new CinemaEmployee(){Cinema = _db.Cinema.Find(id)});
            return View(objList);
        }

        public IActionResult Assign(int id)
        {
            List<string> assignedIds = _db.CinemaEmployee.Where(ce => ce.IdCinema == id).Select(ce => ce.IdEmployee).ToList();
            CinemaEmployeeVM cinemaEmployeeVM = new CinemaEmployeeVM()
            {
                IdCinema = id,
                EmployeeCheckBoxList = _db.Employee.Where(e => e.IdManager == _userManager.GetUserId(User) &&
                    !assignedIds.Contains(e.Id)).Select(e => new CheckBoxItem
                {
                    IdString = e.Id,
                    Object = e,
                    IsChecked = false
                }).ToList()
            };

            return View(cinemaEmployeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(CinemaEmployeeVM cinemaEmployeeVM)
        {
            foreach (var obj in cinemaEmployeeVM.EmployeeCheckBoxList)
            {
                if (obj.IsChecked)
                {
                    CinemaEmployee cinemaEmployee = new CinemaEmployee()
                    {
                        IdCinema = cinemaEmployeeVM.IdCinema,
                        IdEmployee = obj.IdString
                    };
                    _db.Add(cinemaEmployee);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id = cinemaEmployeeVM.IdCinema });
        }

        public IActionResult Delete(int id)
        {
            CinemaEmployee obj = _db.CinemaEmployee.Where(ce => ce.Id == id).Include(c => c.Cinema).Include(e => e.Employee).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult DeleteConfirm(int id)
        {
            CinemaEmployee obj = _db.CinemaEmployee.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = obj.IdCinema });
        }
    }
}
