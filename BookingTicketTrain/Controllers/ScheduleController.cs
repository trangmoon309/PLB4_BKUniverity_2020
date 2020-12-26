using BookingTicketTrain.Models;
using BookingTicketTrain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleServices scheduleServices;
        private readonly AppDbContext dbContext;

        public ScheduleController(IScheduleServices scheduleServices, AppDbContext dbContext)
        {
            this.scheduleServices = scheduleServices;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult CreateSchedule()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(Schedule model)
        {
            ViewBag.Result = false;
            if(ModelState.IsValid)
            {
                if(model.CountryFrom.Equals(model.CountryTo))
                {
                    ModelState.AddModelError("", "Destination country must be different from Starting country!");
                    ViewBag.Result = false;
                    return View(model);
                }
                var result = await scheduleServices.CreateSchedule(model);
                if(result)
                {
                    ViewBag.Result = true;
                    return View(model);
                }
                ModelState.AddModelError("", "This seat Already created!");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetListSchedule(string desCountryName)
        {
            ViewBag.countryto = desCountryName;
            var schedules = dbContext.schedules.Where(x => x.CountryTo.Equals(desCountryName)).Select(x =>x);
            return View(schedules.ToList());
        }

        [HttpGet]
        public IActionResult GetListSchedule2()
        {
            return View();
        }

    }
}
