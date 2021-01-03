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
            List<CinemaEmployee> objList = _db.CinemaEmployee.Where(ce => ce.IdCinema == id).Include(c => c.Cinema).Include(e => e.Employee).Where(e => e.Employee.IdManager != null).ToList();
            if (objList.Count == 0)
                objList.Add(new CinemaEmployee(){Cinema = _db.Cinema.Find(id)});
            return View(objList);
        }

        public IActionResult ManagerIndex(int id)
        {
            List<CinemaEmployee> objList = _db.CinemaEmployee.Where(ce => ce.IdCinema == id).Include(c => c.Cinema).Include(e => e.Employee).Where(e => e.Employee.IdManager == null).ToList();
            if (objList.Count == 0)
                objList.Add(new CinemaEmployee() { Cinema = _db.Cinema.Find(id) });
            return View(objList);
        }

        public IActionResult Assign(int id)
        {          
            List<string> assignedIds = _db.CinemaEmployee.Include(ce => ce.Employee).Where(ce => ce.IdCinema == id && ce.Employee.IdManager != null).Select(ce => ce.IdEmployee).ToList();
            List<CheckBoxItem> employeeCheckBoxList = new List<CheckBoxItem>();
            if (User.IsInRole(WebConstants.AdminRole))
            {
                employeeCheckBoxList = _db.Employee.Where(e => e.IdManager != null && !assignedIds.Contains(e.Id)).Select(e => new CheckBoxItem
                    {
                        IdString = e.Id,
                        Object = e,
                        IsChecked = false
                    }).ToList();
            }
            else
            {
                employeeCheckBoxList = _db.Employee.Where(e => e.IdManager == _userManager.GetUserId(User) &&
                    !assignedIds.Contains(e.Id)).Select(e => new CheckBoxItem
                    {
                        IdString = e.Id,
                        Object = e,
                        IsChecked = false
                    }).ToList();
            }
            if (employeeCheckBoxList.Count == 0)
                employeeCheckBoxList.Add(new CheckBoxItem()
                {
                    IdString = "",
                    Object = new Employee() { IdManager = "_"}
                });
            CinemaEmployeeVM cinemaEmployeeVM = new CinemaEmployeeVM()
            {
                IdCinema = id,
                EmployeeCheckBoxList = employeeCheckBoxList
            };

            return View(cinemaEmployeeVM);
        }

        public IActionResult ManagerAssign(int id)
        {
            List<string> assignedIds = _db.CinemaEmployee.Include(ce => ce.Employee).Where(ce => ce.IdCinema == id && ce.Employee.IdManager == null).Select(ce => ce.IdEmployee).ToList();
            List<CheckBoxItem> employeeCheckBoxList = _db.Employee.Where(e => e.IdManager == null &&
                    !assignedIds.Contains(e.Id)).Select(e => new CheckBoxItem
                    {
                        IdString = e.Id,
                        Object = e,
                        IsChecked = false
                    }).ToList();
            CinemaEmployeeVM cinemaEmployeeVM = new CinemaEmployeeVM()
            {
                IdCinema = id,
                EmployeeCheckBoxList = employeeCheckBoxList
            };
            if (employeeCheckBoxList.Count == 0)
                employeeCheckBoxList.Add(new CheckBoxItem()
                {
                    IdString = "",
                    Object = new Employee() { IdManager = null }
                });
            return View("Assign", cinemaEmployeeVM);
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
            Employee temp = _db.Employee.Find(cinemaEmployeeVM.EmployeeCheckBoxList.First().IdString);
            if(temp.IdManager == null)
                return RedirectToAction("ManagerIndex", new { id = cinemaEmployeeVM.IdCinema });
            else
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
