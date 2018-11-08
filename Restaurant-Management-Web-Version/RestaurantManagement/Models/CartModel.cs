using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class CartModel
    {
        public int Cart_id { get; set; }
        public int Cu_id { get; set; }
        public decimal Tot_price { get; set; }
        public String Status { get; set; }
        public String online_Onplase { get; set; }
        public String Address { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
    }
}