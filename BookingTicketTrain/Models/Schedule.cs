using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string StationName { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(4)]
        public string Seat { get; set; }
    }
}
