using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class PurOrder
    {
        public PurOrder()
        {
            OrderList = new HashSet<OrderList>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderList> OrderList { get; set; }
    }
}
