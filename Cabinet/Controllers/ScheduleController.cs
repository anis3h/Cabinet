using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Models.CabinetViewModel.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Controllers
{
    public class ScheduleController : Controller
    {

        public IActionResult Index()
        {
            var scheduleViewModel = new ScheduleViewModel();

            return View(scheduleViewModel);
        }
    }
}