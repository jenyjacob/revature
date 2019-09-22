using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.DataAccess
{
   public static class Mapper
    {
        public static Library.Customer Map(Entities.Customer customer) => new Library.Customer
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            PurOrder = customer.PurOrder.Select(Map).ToList()

        };

        public static Entities.Customer Map(Library.Customer customer) => new Entities.Customer
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber =customer.PhoneNumber,
            PurOrder = customer.PurOrder.Select(Map).ToList()

        };

        public static Library.PurOrder Map(Entities.PurOrder purorder) => new Library.PurOrder
        {
            OrderId = purorder.OrderId,
            CustomerId = purorder.CustomerId,
            StoreId = purorder.StoreId,
            OrderDate = purorder.OrderDate,
            Total = purorder.Total,
            OrderList = purorder.OrderList.Select(Map).ToList()
            
        };

        public static Entities.PurOrder Map(Library.PurOrder purorder) => new Entities.PurOrder
        {

            OrderId = purorder.OrderId,
            CustomerId = purorder.CustomerId,
            StoreId = purorder.StoreId,
            OrderDate = purorder.OrderDate,
            Total = purorder.Total,
            OrderList = purorder.OrderList.Select(Map).ToList()
        };

        public static Library.Product Map(Entities.Product product) => new Library.Product
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            InventoryId = product.InventoryId,
            Cost = decimal.ToDouble(product.Cost),
            Inventory = product.Inventory.Select(Map).ToList()

        };

        public static Entities.Product Map(Library.Product product) => new Entities.Product
        {

            ProductId = product.ProductId,
            ProductName = product.ProductName,
            InventoryId = product.InventoryId,
            Cost = Convert.ToDecimal(product.Cost),
            Inventory = product.Inventory.Select(Map).ToList()
            
        };

        public static Library.Store Map(Entities.Store store) => new Library.Store
        {      
            StoreId = store.StoreId,
            StoreLoc = store.StoreLoc,
            Inventory = store.Inventory.Select(Map).ToList(),
            PurOrder = store.PurOrder.Select(Map).ToList()

        };

        public static Entities.Store Map(Library.Store store) => new Entities.Store
        {
            StoreId = store.StoreId,
            StoreLoc = store.StoreLoc,
            PurOrder = store.PurOrder.Select(Map).ToList(),
            Inventory = store.Inventory.Select(Map).ToList()
        };

        public static Entities.OrderList Map(Library.OrderList orderlist) => new Entities.OrderList
        {
            OrderListId = orderlist.OrderListId,
            OrderId = orderlist.OrderId,
            ProductId = orderlist.ProductId,
            UnitPrice = Convert.ToDecimal(orderlist.UnitPrice),
            Qty = orderlist.Qty
        };

        public static Library.OrderList Map(Entities.OrderList orderlist) => new Library.OrderList
        {
            OrderListId = orderlist.OrderListId,
            OrderId = orderlist.OrderId,
            ProductId = orderlist.ProductId,
            UnitPrice = decimal.ToDouble(orderlist.UnitPrice),
            Qty = orderlist.Qty

        };

        public static Entities.Inventory Map(Library.Inventory inventory) => new Entities.Inventory
        {
           InventoryId = inventory.InventoryId,
           ProductId = inventory.ProductId,
           StoreId = inventory.StoreId,
           Qty = inventory.Qty
        };

        public static Library.Inventory Map(Entities.Inventory inventory) => new Library.Inventory
        {
            InventoryId = inventory.InventoryId,
            ProductId = inventory.ProductId,
            StoreId = inventory.StoreId,
            Qty = inventory.Qty

        };

        public static Entities.Cart Map(Library.Cart cart) => new Entities.Cart
        {
            CartId = cart.CartId,
           
            ProductId = cart.ProductId,
            Qty = cart.Qty
        };
        public static Library.Cart Map(Entities.Cart cart) => new Library.Cart
        {
            CartId = cart.CartId,
            
            ProductId = cart.ProductId,
            Qty = cart.Qty
        };
    }
}

