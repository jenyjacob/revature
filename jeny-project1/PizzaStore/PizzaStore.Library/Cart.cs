using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Cart
    {
        public int CartId { get; set; }
      
        public int ProductId { get; set; }
        public int Qty { get; set; }

        public  Product Product { get; set; }
    }
}
