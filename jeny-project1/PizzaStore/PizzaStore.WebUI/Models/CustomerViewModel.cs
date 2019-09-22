using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebUI.Models
{
    public class CustomerViewModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<PurOrderViewModel> Orders { get; set; }
    }
}
