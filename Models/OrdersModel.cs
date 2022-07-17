using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gifts.Models
{
    class OrdersModel
    {
        public int Order_id { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime Ordered_at { get; set; }

    }
}