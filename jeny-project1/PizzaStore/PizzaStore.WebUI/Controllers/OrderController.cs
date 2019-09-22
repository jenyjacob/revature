using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IStoreRepo Repo { get; }
        public OrderController(IStoreRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        // GET: Order
        public ActionResult Index([FromQuery] string search = "")
        {
            var order = Repo.DisplayOrderHistoryByCustomerName(search);
            var viewModel = order.Select(x => new PurOrderViewModel
            {
             
                OrderDate = x.OrderDate,
                OrderId = x.OrderId,
                 Total = x.Total

            });

           
             return View(viewModel);

        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            PurOrder orders = Repo.GetorderDetails(id);
            PurOrderViewModel viewModel = new PurOrderViewModel
            {
                OrderId = orders.OrderId,
                OrderDate = orders.OrderDate,
                Total = orders.Total,
              
                StoreId = orders.StoreId,
                OrderList = orders.OrderList.Select(y => new OrderListViewModel
                {
                    
                    OrderId = y.OrderId,
                    ProductId = y.ProductId,
                    Qty = y.Qty
                }).ToList()
            };
            return View(viewModel);

        }
            // GET: Order/Create
            public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}