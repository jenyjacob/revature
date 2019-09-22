using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Qty { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
