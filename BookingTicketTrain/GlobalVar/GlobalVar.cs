using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketTrain.GlobalVar
{
    public static class GlobalVar
    {
        //sava id-user and timestamp
        public static Dictionary<string, DateTime> arr1 { get; set; } = new Dictionary<string, DateTime>();
        public static List<string> userIdArr { get; set; } = new List<string>();
        public static List<DateTime> timeStamps { get; set; } = new List<DateTime>();

    }
}
