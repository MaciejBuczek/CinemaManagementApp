using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Controllers
{
    public class ScheduleEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
