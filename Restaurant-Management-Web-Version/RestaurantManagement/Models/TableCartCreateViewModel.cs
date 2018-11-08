using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class TableCartCreateViewModel
    {
        public int Table_Id { get; set; }
        public int Capacity { get; set; }
    }
}