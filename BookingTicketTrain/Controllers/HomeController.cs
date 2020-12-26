using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookingTicketTrain.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingTicketTrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppClient user)
        {
            ViewBag.checkLogin = false;
            var checkExistedUser = dbContext.clients.FirstOrDefault(x => x.Username == user.Username);
            if(checkExistedUser!=null)
            {
                ViewBag.checkLogin = true;
                if (checkExistedUser.Password == user.Password)
                {
                    GlobalVariables.UserId = checkExistedUser.AppClientId;
                    return View("Index");
                }    
            }    
            else
            {
                ModelState.AddModelError("", "Password doesn't match!");
            }
            ModelState.AddModelError("", "User doesn't exist");
            return View();
        }

        [HttpGet]
        public IActionResult ListTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
