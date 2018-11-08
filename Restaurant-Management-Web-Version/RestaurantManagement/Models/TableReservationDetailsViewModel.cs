using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class TableReservationDetailsViewModel
    {
        public int Reservation_id { get; set; }
        public int Table_Cart_id { get; set; }
        public int Table_Id { get; set; }
        public int Capacity { get; set; }

    }
}