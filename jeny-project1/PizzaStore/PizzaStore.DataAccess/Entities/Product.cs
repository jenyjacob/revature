using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Inventory = new HashSet<Inventory>();
            OrderList = new HashSet<OrderList>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int InventoryId { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderList> OrderList { get; set; }
    }
}
