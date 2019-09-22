using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Store
    {
       
        public int StoreId { get; set; }

        public string StoreLoc { get; set; }

        public List<Inventory> Inventory { get; set; }

        public List<PurOrder> PurOrder { get; set; }

       // public readonly HashSet<Customer> Customers = new HashSet<Customer>();
        
       
        
        

    }
}
