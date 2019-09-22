using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            PurOrder = new HashSet<PurOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<PurOrder> PurOrder { get; set; }
    }
}
