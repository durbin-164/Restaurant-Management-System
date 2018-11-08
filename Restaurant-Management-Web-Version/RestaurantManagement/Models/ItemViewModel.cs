using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public byte[] image { get; set; }
    }
}