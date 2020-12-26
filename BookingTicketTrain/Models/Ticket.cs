using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Models
{
    public class Ticket
    {
        [ForeignKey("appClient")]
        public string UserId { get; set; }
        [ForeignKey("schedule")]
        public int ScheduleId { get; set; }
        [Key]
        public int Id { get; set; }
        public AppClient appClient { get; set; }
        public Schedule schedule { get; set; }

    }
}
