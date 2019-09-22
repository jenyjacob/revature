using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebUI.Models
{
    public class ProductViewModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int InventoryId { get; set; }

        public double Cost { get; set; }
    }
}
