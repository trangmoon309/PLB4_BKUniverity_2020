using BookingTicketTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Services
{
    public class ScheduleServices : IScheduleServices
    {
        private AppDbContext dbContext;

        public ScheduleServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateSchedule(Schedule createdSchedule)
        {
            var checkExistedseat = from item in dbContext.schedules
                               where item.CountryFrom == createdSchedule.CountryFrom && item.CountryTo == createdSchedule.CountryTo
                               && item.StationName == createdSchedule.StationName
                               select item.Seat;
            foreach(var seat in checkExistedseat)
            {
                if (seat.Equals(createdSchedule.Seat)) return false;
            }

            //var id = dbContext.schedules.Max(x => x.ScheduleId);
            //createdSchedule.ScheduleId = ++id;
            await dbContext.schedules.AddAsync(createdSchedule);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public List<Schedule> GetAllSchedules()
        {
            return dbContext.schedules.ToList();
        }
    }
}
