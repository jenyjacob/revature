using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            PurOrder = new HashSet<PurOrder>();
        }

        public int StoreId { get; set; }
        public string StoreLoc { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<PurOrder> PurOrder { get; set; }
    }
}
