using BookingTicketTrain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTicketTrain.GlobalVar;

namespace BookingTicketTrain.Services
{
    public class TicketServices : ITicketServices
    {
        protected AppDbContext dbContext { get; }

        public TicketServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> BookTicketAsync(int scheduleId, string userId)
        {
            var timestamp = DateTime.UtcNow;
            var id = userId;
            GlobalVar.GlobalVar.userIdArr.Add(id);
            GlobalVar.GlobalVar.timeStamps.Add(timestamp);
            var userId2 = "";
            int i = 0;
            foreach( var item in GlobalVar.GlobalVar.timeStamps)
            {
                if(item == timestamp)
                {
                    if(GlobalVar.GlobalVar.userIdArr.ElementAt(i) != id) userId2 = GlobalVar.GlobalVar.userIdArr.ElementAt(i);
                }
                i++;
            }

            //Nếu có tức là 2 request đồng thời
            if(userId2.Length != 0)
            {
                if(Convert.ToInt32(id[0]) > Convert.ToInt32(userId2[0]))
                {
                    var checkExistedTicket = dbContext.tickets.FirstOrDefaultAsync(x => x.ScheduleId == scheduleId);
                    if (checkExistedTicket.Result != null)
                    {
                        return false;
                    }
                    var createdTicket = new Ticket()
                    {
                        ScheduleId = scheduleId,
                        UserId = userId
                    };
                    await dbContext.tickets.AddAsync(createdTicket);

                    try
                    {
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }    
            }
            else
            {
                var checkExistedTicket = dbContext.tickets.FirstOrDefaultAsync(x => x.ScheduleId == scheduleId);
                if (checkExistedTicket.Result != null)
                {
                    return false;
                }
                var createdTicket = new Ticket()
                {
                    ScheduleId = scheduleId,
                    UserId = userId
                };
                await dbContext.tickets.AddAsync(createdTicket);

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
