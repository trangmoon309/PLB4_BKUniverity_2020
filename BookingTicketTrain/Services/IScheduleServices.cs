using BookingTicketTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Services
{
    public interface IScheduleServices
    {
        List<Schedule> GetAllSchedules();
        Task<bool> CreateSchedule(Schedule createdSchedule);
    }
}
