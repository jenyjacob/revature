using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class OrderList
    {
        public int OrderListId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }

        public virtual PurOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
