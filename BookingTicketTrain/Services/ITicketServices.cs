using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Services
{
    public interface ITicketServices
    {
        Task<bool> BookTicketAsync(int scheduleId, string userId);
    }
}
