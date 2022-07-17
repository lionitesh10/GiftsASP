using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gifts.Models
{
    class ItemUserOrdersModel
    {
        public int ItermOrderId { get; set; }
        public int ItemId { get; set; }
        public int Order_Id { get; set; }
        public float Qty { get; set; }
        public float Rate { get; set; }
        public DateTime OrderAt { get; set; }
    }
}