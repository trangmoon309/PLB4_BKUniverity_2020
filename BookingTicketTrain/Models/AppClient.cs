using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.Models
{
    public class AppClient
    {
        [Key]
        public string AppClientId { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public string Email { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
