using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebUI.Models
{
    public class PlaceOrderModel
    {

        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int productId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public double price { get; set; }

        public double Total { get; set; }

    }
}
