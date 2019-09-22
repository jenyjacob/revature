using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }

        public virtual Product Product { get; set; }
    }
}
