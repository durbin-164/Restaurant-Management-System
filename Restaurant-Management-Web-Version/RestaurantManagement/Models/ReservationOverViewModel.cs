using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class ReservationOverViewModel
    {
        public int Table_Cart_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Start_time { get; set; }
        public string End_Time { get; set; }
    }
}