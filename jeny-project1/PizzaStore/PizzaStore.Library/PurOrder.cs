using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class PurOrder
    {   

        public int OrderId { get; set; }
        public int  CustomerId { get; set; }

        public int StoreId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public  Customer Customer { get; set; }
        public Store Store { get; set; }
        public List<OrderList> OrderList { get; set; } = new List<OrderList>();


    }
}

