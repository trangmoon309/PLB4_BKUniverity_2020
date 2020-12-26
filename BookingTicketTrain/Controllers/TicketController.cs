using BookingTicketTrain.Models;
using BookingTicketTrain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookingTicketTrain.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly ITicketServices ticketServices;

        public TicketController(AppDbContext dbContext, ITicketServices ticketServices)
        {
            this.dbContext = dbContext;
            this.ticketServices = ticketServices;
        }

        [HttpPost]
        public async Task<IActionResult> BookingTicket(int scheId,string userId)
        {
            var id = userId;
            var result = await ticketServices.BookTicketAsync(scheId, id);
            if (result)
            {
                ViewBag.Message = "Success";
                return View("Response");
            }
            ViewBag.Message = "Failed";
            return View("Response");
        }
    }
}
