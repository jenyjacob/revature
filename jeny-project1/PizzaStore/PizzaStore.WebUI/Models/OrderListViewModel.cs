using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebUI.Models
{
    public class OrderListViewModel
    {

        public int OrderListId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }

        
    }
}
