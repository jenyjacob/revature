using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
   public interface IStoreRepo : IDisposable
    {


         IEnumerable<Library.Store> GetAllStore(int id);
        void AddCustomer(Customer customer);
        Customer GetCustomerByName(string name);

        void DisplayOrderlist();
        IEnumerable<Library.Customer> OrderHistoryByCustomer(string phonenumber);
        Library.PurOrder GetorderDetails(int id);
       // IEnumerable<OrderList> GetOrderDetails(int id);
        IEnumerable<Library.Product> GetProductDetails(int id);
        IEnumerable<Customer> GetCustomer(string name);
        IEnumerable<Customer> Getorders();
        // List<PurOrder> DisplayOrderHistoryByCustomer(string name);
        IEnumerable<PurOrder> DisplayOrderHistoryByStoreId(int id);
       // Library.PurOrder GetOrderById(int id);
        IEnumerable<PurOrder> DisplayOrderHistoryByCustomerName(string name = null);
        int AddToCart(Product item);
        IEnumerable<Cart> GetCartItems();
        PurOrder CreateOrder(PurOrder order);




        void Save();
        
    }
}
