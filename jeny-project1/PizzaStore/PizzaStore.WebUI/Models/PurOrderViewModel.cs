using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebUI.Models
{
    public class PurOrderViewModel
    {
        [Display(Name = "Order Number")]
        public int OrderId { get; set; }
        public int OrderListId { get; set; }
        public int StoreId { get; set; }
         public string FirstName { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderListViewModel> OrderList{ get; set; }
        public IEnumerable<ProductViewModel> Product { get; set; }
        public IEnumerable<StoreViewModel> store { get; set; }


    }
}
