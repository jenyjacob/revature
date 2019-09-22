using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderList
    {
        public int OrderListId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }

        public  PurOrder Order { get; set; }
        public  Product Product { get; set; }
        public Store strore { get; set; }



    }
}
