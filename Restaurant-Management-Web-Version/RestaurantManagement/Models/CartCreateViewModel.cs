using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class CartCreateViewModel
    {
       
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public int Quentity { get; set; }
        public decimal Tot_price { get; set; }
       
    }
}