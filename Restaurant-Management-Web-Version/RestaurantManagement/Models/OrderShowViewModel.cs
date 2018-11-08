using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class OrderShowViewModel
    {
        public int Oder_id { get; set; }
        public int Item_id { get; set; }
        public string Item_name{get;set;}
        public string Address { get; set; }

        public int Quentity { get; set; }
        public decimal Price { get; set; }
     //   public string Status { get; set; }
       // public string online_Onplase { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}