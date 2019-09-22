using System;
using System.Collections.Generic;
using PizzaStore.Library;
using System.Text;
using PizzaStore.DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;
using Product = PizzaStore.DataAccess.Entities.Product;

namespace PizzaStore.DataAccess
{
    public class StoreRepo : IStoreRepo
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly PizzaStoreContext _dbContext;


        public StoreRepo(PizzaStoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<Library.Customer> GetCustomer(string search )
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Entities.Customer> items = _dbContext.Customer
                .Include(r => r.PurOrder).AsNoTracking();
            if (search != null)
            {
                items = items.Where(r => r.FirstName.Contains(search));
            }
            return items.Select(Mapper.Map);
        }
        public void AddCustomer(Library.Customer customer)
        {
            Entities.Customer entity = Mapper.Map(customer);

            _dbContext.Add(entity);

        }
        /*public void DisplayStore()
        {
            var storelist = _dbContext.Store;
            var store = storelist.Select(Mapper.Map);
            foreach(Library.Store s in store)
            {
                Console.WriteLine("Store Number: " + s.StoreId + ", Store Location: " + s.StoreLoc);
                Console.WriteLine();
            }
*/

        public IEnumerable<Library.Store> GetAllStore()
        {
            IQueryable<Entities.Store> Store = _dbContext.Store;
          
            return Store.Select(Mapper.Map);
        }
        public IEnumerable<Library.Store> GetAllStore(int id)
        {
            IQueryable<Entities.Store> Store = _dbContext.Store;

            return Store.Select(Mapper.Map);
        }

        /*public Library.Customer GetCustomerById(int id)
        {
            IQueryable<Entities.Customer> items = _dbContext.Customer;
            if (id != null)
            {
                items = items.Where(r => r.FirstName.Contains(id));
            }
            return items.Select(Mapper.Map);
        }*/

        public void DisplayOrderlist()
        {

            var Purorder = _dbContext.PurOrder
                           .Include(x => x.OrderList);
            var ol = Purorder.Select(Mapper.Map);

        }
        public bool VerifyCustomer(string phonenumber)
        {
            return _dbContext.Customer.Any(r => r.PhoneNumber .Equals(phonenumber));
        }

        /*public Library.PurOrder PlaceOrder(string Phonenumber,int store,Dictionary<string, int> product)
        {
            if(VerifyCustomer(Phonenumber)== true)
            {
                Library.PurOrder order = new Library.PurOrder
                {
                    

                    CustomerId =int.Parse( GetCustomer(Phonenumber)),
                    StoreId = store,



                }


            }
        }*/
        public int AddToCart(Library.Product item)
        {
            // Get the matching cart and item instances
            var cartItem = _dbContext.Cart.SingleOrDefault(
                c =>  c.ProductId == item.ProductId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Entities.Cart
                {
                    ProductId = item.ProductId,
                    Qty = 1
                   
                };
                _dbContext.Cart.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Qty++;
            }
            // Save changes
            _dbContext.SaveChanges();

            return cartItem.Qty;
        }
      
        public IEnumerable<Library.Cart> GetCartItems()
        {
            IQueryable<Entities.Cart> cart = _dbContext.Cart;
             return cart.Select(Mapper.Map);

        }
        public  void CreateOrder(Library.PurOrder order)
        {
            decimal orderTotal = 0;
            order.OrderList = new List<Library.OrderList>();

            var cartItems = GetCartItems();
            
            foreach (var item in cartItems)
            {
                var orderDetail = new Library.OrderList
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice =Convert.ToDouble(item.Product.Cost) , 
                    Qty = item.Qty
                };
               
                orderTotal += (item.Qty * Convert.ToDecimal(item.Product.Cost));
                order.OrderList.Add(orderDetail);
                
             //  _dbContext.OrderList.Add(orderDetail);

            }
         
            order.Total = orderTotal;

        
            _dbContext.SaveChanges();
         
            //EmptyCart();
          
            
        }

        public IEnumerable<Library.Customer> OrderHistoryByCustomer(string name)
        {
            IQueryable<Entities.Customer> customer = _dbContext.Customer
                 .Where(y=>y.FirstName == name )
                .Include(r => r.PurOrder)
                .ThenInclude(o => o.OrderList)
                .ThenInclude(p => p.Product);
                
               
            return customer.Select(Mapper.Map);
        }
        public Library.PurOrder GetorderDetails(int id)
        {/*
            var order = _dbContext.PurOrder
                .Include(r => r.OrderList).Where(x => x.OrderId == id);
            return order.ToList();*/
            throw new NotImplementedException();
        }
       /* public Library.PurOrder GetOrderById(int id)
        {
            string s = "helo";
            *//*var order = _dbContext.PurOrder.Include(x => x.OrderList).Where(x => x.OrderId == id).Select(Mapper.Map);
            return order.Select(Mapper.Map);*//*
            return  s;
        }*/
        /*public IEnumerable<Library.OrderList> GetOrderDetails(int id)
        {
            var orderdetails = _dbContext.OrderList.Where(x => x.OrderId == id);
            return orderdetails.Select(Mapper.Map);
        }*/

        public IEnumerable<Library.Product> GetProductDetails(int id)
        {
            var productdetails = _dbContext.Product.Include(x => x.OrderList).Where(x => x.ProductId == id);
            return productdetails.Select(Mapper.Map);
        }

        public IEnumerable<Library.PurOrder> DisplayOrderHistoryByStoreId(int id)
        {
            var store = _dbContext.Store.Include(x => x.PurOrder);
            foreach (var order in store)
            {
                if (order.StoreId == id)
                {
                    var x = order.PurOrder.Select(Mapper.Map);
                    return x.ToList();
                }
            }
            return null;
        }

        public IEnumerable<Library.PurOrder> DisplayOrderHistoryByCustomerName(string name)
        {
            IQueryable<Entities.PurOrder> orders = _dbContext.PurOrder

               .Include(r => r.Customer)
               .Include(o => o.OrderList)
               .ThenInclude(p => p.Product);

            if ( name != null)
            {
                orders = orders.Where(r => r.Customer.FirstName.Contains(name));
            }
            
            return orders.Select(Mapper.Map);
        }

       
      


       /* public Library.Customer GetCustomerByName(string name = null)
        {
            
            if (name != null)
            {
               
                var fname = _dbContext.Customer;
                var customer = fname.Select(Mapper.Map);

                foreach (Library.Customer search in customer)
                {
                    if (search.FirstName ==name)
                    {
                        return search;
                    }
                    
                }
                logger.Warn("Please enter the First Name!! ");
            }
            return null;
        }*/

        /*public List<Library.PurOrder> DisplayOrderHistoryByCustomer(int id)
        {
            var cus = _dbContext.PurOrder.Include(x => x.OrderList).ThenInclude(y=>y.ProductId).Where(r=>r.OrderId == id);
             return cus.Select(Mapper.Map).ToList();
             }*/

        

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }

        public Library.Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Library.PurOrder> Getorders()
        {
            var order = _dbContext.PurOrder;
            return order.Select(Mapper.Map);

        }

        IEnumerable<Library.Customer> IStoreRepo.OrderHistoryByCustomer(string phonenumber)
        {
            IQueryable<Entities.Customer> orders = _dbContext.Customer
                 .Where(y => y.PhoneNumber == phonenumber)
                .Include(r => r.PurOrder)
                .ThenInclude(o => o.OrderList)
                
                .ThenInclude(p => p.Product);


            return orders.Select(Mapper.Map);
        }

        IEnumerable<Library.Customer> IStoreRepo.Getorders()
        {
            throw new NotImplementedException();
        }

        Library.PurOrder IStoreRepo.CreateOrder(Library.PurOrder order)
        {
            throw new NotImplementedException();
        }


















        #endregion
    }
}


