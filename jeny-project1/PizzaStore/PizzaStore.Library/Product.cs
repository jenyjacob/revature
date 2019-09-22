using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int InventoryId { get; set; }

        public double Cost { get; set; }

        public List<OrderList> Invoice { get; set; } = new List<OrderList>();
        public List<Inventory> Inventory { get; set; } = new List<Inventory>();
    }
}
